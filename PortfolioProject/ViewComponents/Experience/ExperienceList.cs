using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PortfolioProject.ViewComponents.Experience
{
	public class ExperienceList: ViewComponent
	{
		ExperienceManager experienceManager = new ExperienceManager(new EFExperienceRepository());

		public IViewComponentResult Invoke()
		{
			var values = experienceManager.TGetList();
			return View(values);
		}
	}
}
