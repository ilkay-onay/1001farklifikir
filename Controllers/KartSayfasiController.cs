using Microsoft.AspNetCore.Mvc;
using farkli1001fikir.Services;

namespace farkli1001fikir.Controllers
{

    public class KartSayfasiController(CardService cardService) : Controller
    {
        public IActionResult Index()
        {
            var publicCards = cardService.GetPublicCards("userId", includePublic: true);
            return View(publicCards);
        }
    }
}
