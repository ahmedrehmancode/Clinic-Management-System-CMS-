using AspNetCoreGeneratedDocument;
using CMS_Clinic_Management_System_.Migrations;
using CMS_Clinic_Management_System_.Models;
using CMS_Clinic_Management_System_.ViewModels;
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
                HttpContext.Session.SetString("adminid", data.Id.ToString());
                return RedirectToAction("index","admin");
            }
            else
            {
                ViewBag.Message = "Invalid credentials";

            }
            return View();
        }
        public IActionResult adminlogout()
        {
            if (HttpContext.Session.GetString("adminid") == null)
            {

                HttpContext.Session.Remove("adminid");
            }
            else
            {
                return RedirectToAction("adminlogin","auth");
            }
            return View();
        }


       

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
            
            
           
            

        
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(string Email,string Password)
        {
            var data = _context.UsersDetails.FirstOrDefault(e => e.UserEmail == Email);
            if (data != null && data.UserPassword == Password)
            {
                HttpContext.Session.SetString("userid", data.UserId.ToString());
                return RedirectToAction("dashboard", "user");
            }
            else {
                ViewBag.Message = "Invalid credentials";
            }

            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();


                }
    }
}
