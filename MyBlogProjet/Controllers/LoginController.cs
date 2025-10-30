using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProjet.Controllers
{
    public class LoginController(SignInManager<AppUser> signInManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(model);
            }

            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }

    }
}
