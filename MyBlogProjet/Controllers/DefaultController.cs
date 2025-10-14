using Microsoft.AspNetCore.Mvc;

namespace MyBlogProjet.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
