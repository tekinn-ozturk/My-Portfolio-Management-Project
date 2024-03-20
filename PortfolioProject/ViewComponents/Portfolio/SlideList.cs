using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent

    {

        private readonly IPortfolioService _portfolioService;

        public SlideList(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

       public IViewComponentResult Invoke()
        {
            var values= _portfolioService.TGetList();
            return View(values);
        }
    }
}
