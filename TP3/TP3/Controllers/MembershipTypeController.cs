using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MembershipTypeController : Controller
    {

        private readonly ApplicationDBContext _db;
        public MembershipTypeController(ApplicationDBContext _db)
        {
            this._db = _db;
        }


        // GET: MembershipTypes
        public IActionResult Index()
        {
            List<MembershipType> membershipTypes = _db.membershiptypes.ToList();
            return View(membershipTypes);
        }

        // GET: MembershipTypes/Details/5
        public IActionResult Details(Guid id)
        {
            MembershipType? membershipType = _db.membershiptypes.Find(id);

            if (membershipType == null)
            {
                return NotFound();
            }

            return View(membershipType);
        }



        // GET: MembershipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembershipTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MembershipType membershipType)
        {
            
            
                _db.membershiptypes.Add(membershipType);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }








        // GET: MembershipTypes/Edit/5
        public IActionResult Edit(Guid id)
        {
            MembershipType? membershipType = _db.membershiptypes.Find(id);

            if (membershipType == null)
            {
                return NotFound();
            }

            return View(membershipType);
        }

        // POST: MembershipTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MembershipType membershipType)
        {
            if (id != membershipType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Entry(membershipType).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipTypeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(membershipType);
        }




        // GET: MembershipTypes/Delete/5
        public IActionResult Delete(Guid id)
        {
            MembershipType? membershipType = _db.membershiptypes.Find(id);

            if (membershipType == null)
            {
                return NotFound();
            }

            return View(membershipType);
        }

        // POST: MembershipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            MembershipType? membershipType = _db.membershiptypes.Find(id);

            if (membershipType == null)
            {
                return NotFound();
            }

            _db.membershiptypes.Remove(membershipType);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool MembershipTypeExists(Guid id)
        {
            return _db.membershiptypes.Any(e => e.Id == id);
        }









    }
}
