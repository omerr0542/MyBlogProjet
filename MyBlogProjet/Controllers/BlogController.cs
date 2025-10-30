using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class BlogController(IBlogService blogService, ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BlogsFromCategory(int id)
        {
            var category = await categoryService.GetByIdAsync(id);
            ViewBag.CategoryName = category.Name;

            var blogs = await blogService.GetBlogsByCategoryIdAsync(id);
            return View(blogs);
        }
    }
}
