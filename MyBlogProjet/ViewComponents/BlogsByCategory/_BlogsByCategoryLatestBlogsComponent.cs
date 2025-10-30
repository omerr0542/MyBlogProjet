using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.ViewComponents.BlogsByCategory
{
    public class _BlogsByCategoryLatestBlogsComponent (IBlogService _blogService) : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _blogService.GetLastNBlogsAsync(3);
            return View(categories);
        }
    }
}
