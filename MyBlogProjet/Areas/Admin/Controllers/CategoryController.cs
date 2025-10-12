using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProjet.Areas.Admin.Controllers
{
    [Area("Admin")] // Controller'ın Admin alanına ait olduğunu belirtir
    public class CategoryController(ICategoryService _categoryService) : Controller
    {

        //private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryService.CreateAsync(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoryService.UpdateAsync(category);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
