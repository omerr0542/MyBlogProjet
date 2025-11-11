using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System.Threading.Tasks;

namespace MyBlogProject.Controllers
{
    public class BlogController(IBlogService blogService, ICategoryService categoryService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var blogs = await blogService.GetAllAsync();
            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);
            return View(values);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await blogService.GetSingleByIdAsync(id);
            return View(blog);
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
