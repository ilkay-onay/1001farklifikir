using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farkli1001fikir.Data;
using farkli1001fikir.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace farkli1001fikir.Services
{
    public class UserService(UserManager<IdentityUser> userManager)
    {
        public async Task<List<IdentityUser>> GetUserListAsync(string username)
    {
        var users = userManager.Users;

    if (!string.IsNullOrEmpty(username))
    {
        users = users.Where(u => u.UserName != null && u.UserName.Contains(username, StringComparison.OrdinalIgnoreCase));
    }


        return await users.ToListAsync();
    }
}
}