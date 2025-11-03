using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogProject.Consts;

namespace MyBlogProject.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class UsersController(UserManager<AppUser> _userManager,
                                IMapper _mapper,
                                RoleManager<AppRole> _roleManager)
        : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                mappedUsers.Find(u => u.Id == user.Id).Roles = userRoles;
                
            }

            return View(mappedUsers);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var userRole = await _userManager.GetRolesAsync(user);


            var assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                assignRoleList.Add(new AssignRoleDto
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExists = userRole.Contains(role.Name)
                });
            }

            ViewBag.FullName = user.FirstName + " " + user.LastName;

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            var userId = model.FirstOrDefault().UserId;
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var item in model)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
