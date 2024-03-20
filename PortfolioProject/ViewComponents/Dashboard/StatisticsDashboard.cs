using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class StatisticsDashboard : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.h1 = c.Portfolios.Count();
            ViewBag.h2 = c.Message.Count();
            ViewBag.h3= c.Services.Count();

            return View();
        }
    }
}
