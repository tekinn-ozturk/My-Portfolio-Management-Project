using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            var values = _socialMediaService.TGetList();
            return View(values);
        }

        public IActionResult AddSocialMedia()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia sm)
        {
            sm.Status = true;
            _socialMediaService.TAdd(sm);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);  
            _socialMediaService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult EditSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia sm)
        {
            sm.Status = true;
           _socialMediaService.TUpdate(sm);
            return RedirectToAction("Index");
        }
    }
}
