using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
        
        public IActionResult Index()
		{
			//Bu controller Views -> Default -> Index'i yönetiyor.
			//PartialView'leri göstermek için Controller ile çalışabiliriz ancak Controller olmadan da PartialView'leri gösterebiliriz.
			return View();
		}

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult SendMessage(Message p)
		{
			MessageManager messageManager = new MessageManager(new EFMessageRepository());
			p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.Status = true;
			messageManager.TAdd(p);
			return PartialView();
			
		}
	}
}
