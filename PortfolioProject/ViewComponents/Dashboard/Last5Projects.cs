using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
             
            return View();
        }
    }
}
