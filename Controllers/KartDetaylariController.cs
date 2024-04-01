using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using farkli1001fikir.Services;
using Microsoft.AspNetCore.Authorization;

namespace farkli1001fikir.Controllers
{
    [Authorize]
public class KartDetaylariController(CardService cardService, UserManager<IdentityUser> userManager) : Controller
{
        public async Task<IActionResult> Index(int id)
    {
        var viewModel = await cardService.GetCardDetails(id);

        if (viewModel == null)
        {
            return NotFound();
        }

        return View(viewModel);
    }

[HttpPost]
public async Task<IActionResult> ManageComment(int cardId, int? commentId, string newText, bool isDelete = false)
{
    var user = await userManager.GetUserAsync(User);

    if (user == null)
    {
        return RedirectToAction("Index", new { id = cardId });
    }

    var success = await cardService.ManageComment(cardId, commentId, newText, user.Id, isDelete);

    if (!success)
    {
        return Forbid();
    }
    return RedirectToAction("Index", new { id = cardId });
}


[HttpPost]
public async Task<IActionResult> Upvote(int cardId)
{
    var user = await userManager.GetUserAsync(User);

    if (user == null)
    {
        return RedirectToAction("Index", new { id = cardId });
    }

    var success = await cardService.Vote(cardId, user.Id, isUpvote: true);

    if (!success)
    {
        TempData["ErrorMessage"] = "Bu kartı zaten oyladınız.";
    }

    return RedirectToAction("Index", new { id = cardId });
}

[HttpPost]
public async Task<IActionResult> Downvote(int cardId)
{
    var user = await userManager.GetUserAsync(User);

    if (user == null)
    {
        return RedirectToAction("Index", new { id = cardId });
    }

    var success = await cardService.Vote(cardId, user.Id, isUpvote: false);

    if (!success)
    {
        TempData["ErrorMessage"] = "Bu kartı zaten oyladınız.";
    }

    return RedirectToAction("Index", new { id = cardId });
}

}
}



