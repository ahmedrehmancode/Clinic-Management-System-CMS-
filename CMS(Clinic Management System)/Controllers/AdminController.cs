using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_project.Controllers
{
    public class AdminController : Controller
    {
       
        
        public IActionResult Index()
        {
           
           return View();

            //return View();

        }

        public IActionResult Profile()
        {
            return View();
        }
        
       
        
       
    }
}
