using CMS_Clinic_Management_System_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_project.Controllers
{
    public class AdminController : Controller
    {
        private Mydbcontext _db;

        public AdminController(Mydbcontext context)
        {
            _db = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("adminid") != null)
            {
                return View();
               

            }
            else
            {
                return RedirectToAction("adminlogin", "auth");

            }

            //return View();

        }
        
       
        
       
    }
}
