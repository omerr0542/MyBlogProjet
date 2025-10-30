using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
