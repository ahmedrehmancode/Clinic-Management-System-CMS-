using CMS_Clinic_Management_System_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_project.Controllers
{
    public class ClientController : Controller
    {
        private readonly Mydbcontext _db;

        public ClientController(Mydbcontext context)
        {
            _db = context;
        }

        // Session check helper
        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("adminid") != null;
        }

        // 1. Show all clients
        public IActionResult Index()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            var clients = _db.Clients.ToList();
            return View(clients); // Views/Client/Index.cshtml
        }

        // 2. Show form to create new client
        public IActionResult Create()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            return View(); // Views/Client/Create.cshtml
        }

        // 3. Store new client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            if (ModelState.IsValid)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // 4. Show single client details
        public IActionResult Details(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            var client = _db.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client); // Views/Client/Details.cshtml
        }

        // 5. Show form to edit client
        public IActionResult Edit(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            var client = _db.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client); // Views/Client/Edit.cshtml
        }

        // 6. Update client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            if (ModelState.IsValid)
            {
                _db.Clients.Update(client);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // 7. Delete client (show confirmation)
        public IActionResult Delete(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            var client = _db.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client); // Views/Client/Delete.cshtml
        }

        // 8. Delete client (confirmed)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login", "Admin");

            var client = _db.Clients.Find(id);
            if (client != null)
            {
                // Safe delete: catch FK constraint exceptions
                try
                {
                    _db.Clients.Remove(client);
                    _db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception or show friendly message
                    TempData["Error"] = "Cannot delete client. Related records exist.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
