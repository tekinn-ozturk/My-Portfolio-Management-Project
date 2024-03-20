using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
