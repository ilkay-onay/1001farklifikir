using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using farkli1001fikir.Models;
using farkli1001fikir.Services;


namespace farkli1001fikir.Controllers
{
    [Authorize]
public class KartlarimController(UserManager<IdentityUser> userManager, CardService cardService) : Controller
{
        public IActionResult Index()
    {
        var userId = userManager.GetUserId(User);
        if (userId == null)
        {
            return RedirectToAction("Error");
        }

        var userCards = cardService.GetCardsForUser(userId);
        return View(userCards);
    }

    public IActionResult Edit(int id)
    {
        var userId = userManager.GetUserId(User);
        if (userId == null)
        {
            return RedirectToAction("Error");
        }

        var userCard = cardService.GetUserCardById(id, userId);

        if (userCard == null)
        {
            return NotFound();
        }

        return View(userCard);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var userId = userManager.GetUserId(User);
        if (userId == null)
        {
            return RedirectToAction("Error");
        }

        var result = cardService.DeleteCard(id, userId);

        if (!result)
        {
            return NotFound();
        }

        return RedirectToAction("Index");
    }

[HttpPost]
public IActionResult UpdateCard(CardModel updatedCard)
{
    if (!ModelState.IsValid)
    {
        return View("Edit", updatedCard);
    }

    var userId = userManager.GetUserId(User);
    if (userId == null)
    {
        return RedirectToAction("Error");
    }

    if (!cardService.SaveOrUpdateCard(updatedCard, userId))
    {
        return View("Error");
    }

    return RedirectToAction("Index");
}

}

}
