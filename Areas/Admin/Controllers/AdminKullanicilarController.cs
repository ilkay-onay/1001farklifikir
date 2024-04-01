using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using farkli1001fikir.Services;

namespace farkli1001fikir.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminKullanicilarController(UserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserList(string username)
        {
            var userList = await userService.GetUserListAsync(username);

            return Json(new { data = userList });
        }
    }
}

