using CMS_Clinic_Management_System_.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    
    public class AuthController : Controller
    {
        private Mydbcontext _context;
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
        public IActionResult logout()
        {
            if (HttpContext.Session.GetString("adminid") == null)
            {

                HttpContext.Session.Remove("adminid");
            }
            else
            {
                return RedirectToAction("login","auth");
            }
            return View();
        }
    }
}
