using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterAppUser> _userManager;

        public AdminNavbarMessageList(IWriterMessageService writerMessageService, UserManager<WriterAppUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        
        {
           
            string p = "admin@gmail.com";
            var values = _writerMessageService.TGetListReceiverMessage(p).OrderByDescending(x=>x.Id).Take(3).ToList();
            //mesajı atan kişinin fotoğrafına ihtiyacım var ve WriteAppUser and WriterMessage arasında bir ilişki yok.
            //var user =await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.p=$"~/user-img/{user.ImageUrl}";
         




            return View(values);

        }

    }
}









