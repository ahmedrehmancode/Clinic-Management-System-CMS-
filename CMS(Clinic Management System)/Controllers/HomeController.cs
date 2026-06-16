using System.Diagnostics;
using CMS_Clinic_Management_System_.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
        public IActionResult Error()
        {
            return View();
        }
    }
}
