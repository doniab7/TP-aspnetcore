using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class MovieController : Controller
    {

        private readonly AppDbContext _db;
        public MovieController(AppDbContext _db)
        {
            this._db = _db;
        }


        public IActionResult Index()
        {
  
            return View(_db.movies.ToList());
        }



        //POST
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult OnPost(Guid? id)
        {
            if (id == null) return NotFound();
            var m = _db.movies.FirstOrDefault(c => c.Id == id);
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(Movie movie, Guid id)
        {
            var c = _db.movies.Find(id);
            c.Name = movie.Name;
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
            var movie = _db.movies.Find(id);
            if (movie == null)
            {
                return NotFound(); 
            }
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }





        //DELETE
        public IActionResult Delete(int id)
        {
            var movie = _db.movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound(); 
            }
            _db.movies.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }





        public IActionResult Details(Guid? id)
        {
            if (id == null) return Content("unable to find Id");
            var c = _db.movies.SingleOrDefault(c => c.Id == id);
            return View(c);
        }





    }
}
