using CMS_Clinic_Management_System_.Models;
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
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminid") == null)
            {
                

                return RedirectToAction("login");
            }
            else
            {
                return View();
            }

            //return View();

        }
        
       
        
       
    }
}
