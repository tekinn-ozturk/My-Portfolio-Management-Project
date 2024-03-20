using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
	public class FeatureController : Controller
	{
		FeatureManager featureManager = new FeatureManager(new EFFeatureRepository());
		public IActionResult Index()
		{
			
			var values = featureManager.TGetById(1);
			//zaten veri tabanında bir değerimiz var ve onun id si 1 miş baktım.
			return View(values);
		}

		[HttpPost]
		public IActionResult Index(Feature feature)
		{
			featureManager.TUpdate(feature);
			return RedirectToAction("Index","Default");	
		}

	}
}
