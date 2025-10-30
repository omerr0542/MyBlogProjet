using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
