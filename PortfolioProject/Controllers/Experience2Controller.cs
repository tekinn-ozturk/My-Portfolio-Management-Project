using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public IActionResult GetById(int ExperienceId)
        {

            var values = JsonConvert.SerializeObject(_experienceService.TGetById(ExperienceId));
            return Json(values);

        }

        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceService.TGetById(id);
            _experienceService.TDelete(values);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience e)
        {

            //var updatedExp = new Experience()
            //{
            //    ExperienceId = e.ExperienceId,
            //    Name = e.Name,
            //    Date = e.Date,
            //    ImageUrl = e.ImageUrl,
            //    Description = e.Description
            //};

            var values = _experienceService.TGetById(e.ExperienceId);
            values.ExperienceId= e.ExperienceId;
            values.Name= e.Name;
            values.Date= e.Date;
            values.ImageUrl= e.ImageUrl;
            values.Description= e.Description;

            _experienceService.TUpdate(values);
            var values2 = JsonConvert.SerializeObject(values);
            return Json(values2);

        }

    }
}
