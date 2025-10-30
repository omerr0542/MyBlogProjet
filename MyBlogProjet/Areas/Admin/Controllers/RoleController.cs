using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBlogProjet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController(RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AppRole role)
        {
            var result = await _roleManager.CreateAsync(role);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(role);
            }

            return RedirectToAction("Index");
        }
    }
}
