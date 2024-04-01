using Microsoft.AspNetCore.Mvc;
using farkli1001fikir.Models;
using farkli1001fikir.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace farkli1001fikir.Controllers
{
    [Authorize]
    public class KartOlusturController(CardService cardService, UserManager<IdentityUser> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

[HttpPost]
public IActionResult SaveCard(CardModel card)
{
    if (ModelState.IsValid)
    {
        try
        {
            string userId = userManager.GetUserId(User) ?? "defaultUserId";
            cardService.SaveOrUpdateCard(card, userId);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error saving to the database: {ex.Message}");
            return View("Index", card);
        }
    }
    else
    {
        foreach (var modelStateKey in ModelState.Keys)
        {
            var modelStateVal = ModelState[modelStateKey];

            if (modelStateVal != null)
            {
                foreach (var error in modelStateVal.Errors)
                {
                    System.Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                }
            }
        }

        return View("Index", card);
    }

    return RedirectToAction("Index");
}


    }
}
