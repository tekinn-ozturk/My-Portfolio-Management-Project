using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Skill
{
	public class SkillList : ViewComponent
	{
		SkillManager skillManager = new SkillManager(new EFSkillRepository());
		public IViewComponentResult Invoke()
		{
			var values = skillManager.TGetList();
			return View(values);
		}
	}

}
