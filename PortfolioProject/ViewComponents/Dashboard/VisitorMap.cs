using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class VisitorMap: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
