using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.ViewComponents
{
    public class Notification: ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public Notification(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetList().Take(3);
            return View(values);
        }
    }
}
