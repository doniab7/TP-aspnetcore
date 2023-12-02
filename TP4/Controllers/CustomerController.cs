using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;
        public CustomerController(AppDbContext _db)
        {
            this._db = _db;
        }

        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }


        public IActionResult Create()
        {
            var members = _db.Membershiptypes.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            if (!ModelState.IsValid)
            {
                var members = _db.Membershiptypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Name,
                    Value = members.Id.ToString()
                });
                return View();
            }

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            c.Id = new int();
            _db.Customers.Add(c);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Get the list of membership types
            var members = _db.Membershiptypes.ToList();

            // Set the selected value based on the customer's membership type
            ViewBag.member = members.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
            });

            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Details(int? id)
        {
            if (id == null) return Content("unable to find Id");
            var c = _db.Customers.SingleOrDefault(c => c.Id == id);
            return View(c);
        }
    }
}
