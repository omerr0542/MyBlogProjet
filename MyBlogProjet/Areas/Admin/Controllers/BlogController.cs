using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MyBlogProjet.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class BlogController(IBlogService _blogService, ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var blogs = await _blogService.GetBlogsWithCategoryAsync();
        return View(blogs);
    }

    private async Task GetCategoriesAsync()
    {
        var categories = await categoryService.GetAllAsync();

        ViewBag.Categories = (from category in categories
                              select new SelectListItem
                              {
                                  Text = category.Name,
                                  Value = category.Id.ToString()
                              }).ToList();
    }

    [HttpGet]
    public async Task<IActionResult> CreateBlog()
    {
        await GetCategoriesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogDto blog)
    {
        if (!ModelState.IsValid)
        {
            await GetCategoriesAsync(); // Kategorileri tekrar yükle
            return View(blog);
        }

        await _blogService.CreateAsync(blog);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlog(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        await GetCategoriesAsync();
        return View(blog);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBlog(UpdateBlogDto blog)
    {
        if (!ModelState.IsValid)
        {
            await GetCategoriesAsync(); 
            return View(blog);
        }
        await _blogService.UpdateAsync(blog);
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> DeleteBlog(int id)
    {
        await _blogService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
