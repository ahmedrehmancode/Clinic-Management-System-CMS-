using AspNetCoreGeneratedDocument;
//using CMS_Clinic_Management_System_.Migrations;
using CMS_Clinic_Management_System_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using User = CMS_Clinic_Management_System_.Models.User;
using CMS.Domain.Models;



namespace CMS_Clinic_Management_System_.Controllers
{
    
    public class AuthController : Controller
    {
        
        
         //Admin login View

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string Email, string Password)
        {
            return RedirectToAction();

        }
        //logout ACtion
        public IActionResult logout()
        {



            return View();
        }



        //user sign up View
        public IActionResult UserSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserSignUp(SignupViewModle model)
        {
           


                return RedirectToAction("UserLogin");



         




        }



        //Forgotpassowrd View
        public IActionResult ForgotPassword()
        {
            return View();


         }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
        

                return View();

        }
        //conform password action
        public IActionResult ChangePassword(int id)
        {
          

                    
            return View();
        }


        [HttpPost]
        public IActionResult ChangePassword(int id, string password, string conformpassword)
        {




            return RedirectToAction();
        }
        //userlogin view
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(string Email, string Password)
        {

            return RedirectToAction();
        }

    }
    }

