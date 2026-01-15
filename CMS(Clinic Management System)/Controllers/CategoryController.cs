using CMS_Clinic_Management_System_.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Clinic_Management_System_.Controllers
{
    public class CategoryController : Controller
    {
       private Mydbcontext _db;
       public CategoryController(Mydbcontext context)
       {
            _db = context;
        
        
        
        
        }
        public IActionResult Index()
        {



            return View();

        }
        [HttpPost]
        public IActionResult Index(Category cate)
        {
            var data = _db.Categories.Add(cate);
            _db.SaveChanges();
            ViewBag.Done = cate + "Added";
            return View();





        }



    }
}
