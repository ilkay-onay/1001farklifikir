using Microsoft.AspNetCore.Mvc;

namespace farkli1001fikir.Controllers
{
    public class EasterEggController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}