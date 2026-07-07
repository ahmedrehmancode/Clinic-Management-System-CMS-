using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
