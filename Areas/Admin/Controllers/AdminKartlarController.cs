using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using farkli1001fikir.Services;

namespace farkli1001fikir.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminKartlarController(CardService cardService) : Controller
    {
public IActionResult Index(int page = 1, int pageSize = 10)
{
    var cards = cardService.GetCardsForAdmin(page, pageSize);
    return View(cards);
}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = cardService.DeleteCard(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}

