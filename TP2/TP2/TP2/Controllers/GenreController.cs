using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _db;
        public GenreController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.genres.ToList());
        }


        //POST
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            _db.genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult OnPost(Guid? id)
        {
            if (id == null) return NotFound();
            var m = _db.genres.FirstOrDefault(c => c.Id == id);
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(Genre genre, Guid id)
        {
            var c = _db.genres.Find(id);
            c.Name = genre.Name;
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException db)
            {
                TempData["message"] = $"Cannot Add : {db.Message}";
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }







        //PUT (modify)
        public IActionResult Edit(Guid id)
        {
            var genre = _db.genres.Find(id);

            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(genre).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }





        //DELETE
        public IActionResult Delete(Guid id)
        {
            var genre = _db.genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = _db.genres.Find(id);
            if (genre == null)
            {
                return NotFound(); 
            }
            _db.genres.Remove(genre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
