using Microsoft.AspNetCore.Mvc;

namespace TP5.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
