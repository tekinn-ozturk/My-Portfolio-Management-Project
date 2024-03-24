using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioProject.Controllers
{
    public class Experience2Controller : Controller
    {
        private readonly IExperienceService _experienceService;

        public Experience2Controller(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {


            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(_experienceService.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience e)
        {
            _experienceService.TAdd(e);
            var values = JsonConvert.SerializeObject(e);
            return Json(values);

        }
    }
}
