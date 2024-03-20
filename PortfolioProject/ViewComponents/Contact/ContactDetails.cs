using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Contact
{
	public class ContactDetails : ViewComponent
	{
		ContactManager contactManager = new ContactManager(new EFContactRepository());
		public IViewComponentResult Invoke()
		{
			var values = contactManager.TGetList();
			
			return View(values);
		}
	}
}
