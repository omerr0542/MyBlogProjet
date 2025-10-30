using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MyBlogProject.Areas.Admin.Controllers
{
    [Authorize]
    public class UsersController(UserManager<AppUser> userManager, IMapper _mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);
            foreach (var user in users)
            {
                var userRoles = await userManager.GetRolesAsync(user);  
                foreach (var role in mappedUsers)
                {
                    role.Roles = userRoles.ToList();
                }
            }

            return View(mappedUsers);
        }
    }
}
