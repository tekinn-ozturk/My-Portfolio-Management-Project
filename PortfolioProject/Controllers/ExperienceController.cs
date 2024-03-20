using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
	[Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceRepository());
        public IActionResult Index()
        {
			
			var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
			
			return View();
        }

		[HttpPost]
		public IActionResult AddExperience(Experience experience)
		{
            experienceManager.TAdd(experience);

			return RedirectToAction("Index");
		}

		public IActionResult DeleteExperience(int id)
		{

			var experience = experienceManager.TGetById(id);
			if (experience == null)
			{
				throw new Exception("Null Exception");
			}
			experienceManager.TDelete(experience);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditExperience(int id)
		{
			
			var values = experienceManager.TGetById(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult EditExperience(Experience experience)
		{
			experienceManager.TUpdate(experience);
			return RedirectToAction("Index");
		}
	}
}
