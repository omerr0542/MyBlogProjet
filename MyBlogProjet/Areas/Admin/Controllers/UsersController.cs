using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBlogProjet.Areas.Admin.Controllers
{
    public class UsersController(UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            return View(users);
        }
    }
}
