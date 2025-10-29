
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProjet.ViewComponents.Default_Index
{
    public class _DefaultBlogsComponent (ICategoryService categoryService): ViewComponent
    {
        // Invoke Methodu asenkron ise InvokeAsync olarak tanımlanmak zorundadır.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetCategoriesWithBlogsAsync();
            return View(categories);
        }
    }
}
