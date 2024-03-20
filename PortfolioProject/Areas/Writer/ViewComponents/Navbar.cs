using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.ViewComponents
{
    public class Navbar: ViewComponent
    {
        private readonly UserManager<WriterAppUser> _userManager;

        public Navbar(UserManager<WriterAppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.p= values.ImageUrl;
            return View();  
        }
    }
}
