using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("userid") == null) {

                return RedirectToAction("userlogin","auth");
   
            }

            return View(); 
        }

    }
}