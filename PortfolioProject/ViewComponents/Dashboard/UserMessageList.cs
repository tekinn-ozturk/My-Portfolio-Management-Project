using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class UserMessageList : ViewComponent
    {

   
        public IViewComponentResult Invoke()
        {
            
            return View();    
        }
    }
}
