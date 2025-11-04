using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Consts;

namespace MyBlogProjet.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize]
    public class ProfileController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var mappedUser = _mapper.Map<EditProfileDto>(user);
            return View(mappedUser);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var passwordCorrect = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);

            if (!passwordCorrect)
            {
                ModelState.AddModelError("", "Şifre Hatalı!");
                return View(model);
            }

            if (model.ImageFile is not null)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images/", imageName);

                using var stream = new FileStream(saveLocation, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);

                user.ProfileImageUrl = "/images/" + imageName;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            user.Title = model.Title;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(model);
            }
            return RedirectToAction("Index", "Blog", new { area = Roles.Admin});
        }
    }
}
