using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}
