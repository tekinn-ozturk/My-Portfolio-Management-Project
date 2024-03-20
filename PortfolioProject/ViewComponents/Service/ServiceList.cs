using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Service
{
	public class ServiceList : ViewComponent
	{
		ServiceManager serviceManager = new ServiceManager(new EFServiceRepository());
		public IViewComponentResult Invoke()
		{
			var values = serviceManager.TGetList();
			return View(values);
		}
	}

}
