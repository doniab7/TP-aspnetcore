using Microsoft.AspNetCore.Mvc;
using TP4.Models;
using TP4.Services.ServiceContracts;

namespace TP4.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMovieService _movieService;

        public MovieController(AppDbContext db, IMovieService movieService)
        {
            _db = db;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View(_movieService.GetAllMovies());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMovie(Movie movie)
        {
            _movieService.CreateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);

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
                if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                {
                    // Enregistrez le fichier image sur le serveur
                    var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        movie.ImageFile.CopyTo(stream);
                    }

                    // Enregistrez le chemin de l'image dans la base de données
                    movie.Photo = $"/images/{movie.ImageFile.FileName}";
                }
                _movieService.Edit(movie);
                return RedirectToAction("Index");


            }

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);

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
            var movie = _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Delete the image file from the /images folder
            if (!string.IsNullOrEmpty(movie.Photo))
            {
                var imagePath = Path.Combine("wwwroot", movie.Photo.TrimStart('/'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _movieService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return Content("unable to find Id");
            var c = _movieService.GetMovieById(id.Value);
            return View(c);
        }


        /*called new views for LINQ part tp4*/

        public IActionResult MoviesByGenre(int id)
        {
            var movies = _movieService.GetMoviesByGenre(id);
            return View("MoviesByGenre", movies);
        }


        public IActionResult MoviesOrderedAscending()
        {
            var movies = _movieService.GetAllMoviesOrderedAscending();
            return View("MoviesOrderedAscending", movies);
        }

        public IActionResult MoviesByUserDefinedGenre(string name)
        {
            var movies = _movieService.GetMoviesByUserDefinedGenre(name);
            return View("MoviesByUserDefinedGenre", movies);
        }
    }
}
