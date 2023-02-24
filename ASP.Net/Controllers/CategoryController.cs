using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
