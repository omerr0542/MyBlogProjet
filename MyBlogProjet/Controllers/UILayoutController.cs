using Microsoft.AspNetCore.Mvc;

namespace MyBlogProjet.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
