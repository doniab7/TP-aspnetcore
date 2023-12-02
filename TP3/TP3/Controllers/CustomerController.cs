using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using TP3.Models;

namespace TP3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CustomerController(ApplicationDBContext _db)
        {
            this._db = _db;
        }


        // GET: Customers
        public IActionResult Index()
        {
            List<Customer> customers = _db.customers
                .Include(c => c.MembershipType)
                .Include(c => c.Movies)
                .ToList();

            return View(customers);
        }

        // GET: Customers/Details/5
        public IActionResult Details(Guid id)
        {
            Customer? customer = _db.customers
                .Include(c => c.MembershipType)
                .Include(c => c.Movies)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }



        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.MembershipTypes = _db.membershiptypes.ToList();
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            
                _db.customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
           
        }



        private bool CustomerExists(Guid id)
        {
            return _db.customers.Any(e => e.Id == id);
        }


        // GET: Customers/Edit/5
        public IActionResult Edit(Guid id)
        {
            Customer? customer = _db.customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.MembershipTypes = _db.membershiptypes.ToList();
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Entry(customer).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewBag.MembershipTypes = _db.membershiptypes.ToList();
            return View(customer);
        }




        // GET: Customers/Delete/5
        public IActionResult Delete(Guid id)
        {
            Customer? customer = _db.customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Customer? customer = _db.customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            _db.customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


       


    }

}

    