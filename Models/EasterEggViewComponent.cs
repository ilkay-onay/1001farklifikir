using Microsoft.AspNetCore.Mvc;
namespace farkli1001fikir.Models
{
public class EasterEggViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var easterEggMessage = "You found the Easter Egg!";
        return View("Default", easterEggMessage);
    }
}
}
