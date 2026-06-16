using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class UserController : Controller
    {

       
        public IActionResult Dashboard()
        {
           

            return View(); 
        }

    }
}