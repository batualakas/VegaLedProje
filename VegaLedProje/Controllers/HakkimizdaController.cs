using Microsoft.AspNetCore.Mvc;

namespace VegaLedProje.Controllers
{
    public class Hakkimizda : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
