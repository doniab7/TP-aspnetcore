using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers
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
            return View(_db.Genres.ToList());
        }
    }
}
