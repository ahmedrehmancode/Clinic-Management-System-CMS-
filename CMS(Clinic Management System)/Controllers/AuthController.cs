using AspNetCoreGeneratedDocument;
using CMS_Clinic_Management_System_.Migrations;
using CMS_Clinic_Management_System_.Models;
using CMS_Clinic_Management_System_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = CMS_Clinic_Management_System_.Models.User;



namespace CMS_Clinic_Management_System_.Controllers
{
    
    public class AuthController : Controller
    {
        
        private Mydbcontext _context;
        private object clinic;

        public AuthController(Mydbcontext context)
        {
            _context = context;
            
        }
         //Admin login View

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string Email, string Password)
        {

            var data = _context.Admins.FirstOrDefault(a => a.Email == Email);
            if (data != null && data.Password == Password)
            {
                HttpContext.Session.SetInt32("adminid", data.Id);
                HttpContext.Session.SetString("Role", data.Role);
                return RedirectToAction("index","admin");
            }
            else
            {
                ViewBag.errorMessage = "Invalid credentials";

            }
            return View();
        }
        //logout ACtion
        public IActionResult logout()
        {

            
            if (HttpContext.Session.GetInt32("adminid") != null)
            {
                    
                        HttpContext.Session.Clear();
                        return RedirectToAction("adminlogin");
                  

                
            }
            else if (HttpContext.Session.GetString("userid") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("userlogin");

            }
            return View();
        }



        //user sign up View
        public IActionResult UserSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserSignUp(SignupVM model)
        {
            if (ModelState.IsValid) {
                
                ClinicDetail newClinic = new ClinicDetail { 
                
                 ClinicName = model.ClinicName,
                Address = model.Address,
                Phone = model.Phone
                };

                _context.clinicDetails.Add(newClinic);
                _context.SaveChanges();

                User newUser = new User
                {
                    UserEmail = model.UserEmail,
                    UserPassword = model.UserPassword,
                    Role = "CLient",
                    ClinicId = newClinic.ClinicId
                };
                _context.UsersDetails.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("UserLogin");



                
            }

            return View(model);




        }



        //Forgotpassowrd View
        public IActionResult ForgotPassword()
        {
            return View();


         }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
           var data = _context.UsersDetails.FirstOrDefault(e => e.UserEmail == email);
            if (data != null)
            {
                return RedirectToAction("ChangePassword", new {id = data.UserId});

            }
            else
            {
                ViewBag.Messege = "Email Not Found";
               
                
            }

                return View();

        }
        //conform password action
        public IActionResult ChangePassword(int id)
        {
            ViewBag.Id = id;
            

                    
            return View();
        }


        [HttpPost]
        public IActionResult ChangePassword(int id, string password, string conformpassword)
        {
            var data = _context.UsersDetails.FirstOrDefault(p => p.UserId == id);
            if (data != null)
            {

                if (password == conformpassword)
                {
                    data.UserPassword = password;
                    _context.SaveChanges();
                    return RedirectToAction("UserLogin");

                }
                else
                {
                    ViewBag.cpass = "Passowrd Dosn't Match";
                    return View();

                }





            }
            
           
           
            return View();
        }
        //userlogin view
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(string Email, string Password)
        {
            var data = _context.UsersDetails.FirstOrDefault(e => e.UserEmail == Email);
            if (data != null && data.UserPassword == Password)
            {
                HttpContext.Session.SetString("userid", data.UserId.ToString());
                return RedirectToAction("dashboard", "user");
            }
            else
            {
                ViewBag.erroMessage = "Invalid credentials";
            }

            return View();
        }

    }
    }

