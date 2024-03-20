using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceRepository());

        public IActionResult Index()
        {
			
			var values = serviceManager.TGetList();
            return View(values);
        }


		[HttpGet]
		public IActionResult AddService()
		{
			
			return View();
		}



		[HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index","Service");
        }

       
        public IActionResult DeleteService(int id)
        {
            Service service = serviceManager.TGetById(id);
            if (service ==null)
            {
                throw new Exception("Null Exception");
            }
            serviceManager.TDelete(service);        
            return RedirectToAction("Index","Service");
        }
        
        public IActionResult EditService(int id)
        {
			
            var values = serviceManager.TGetById(id);
			return View(values);
		}

        [HttpPost]
		public IActionResult EditService(Service service)
		{

            serviceManager.TUpdate(service);
            return RedirectToAction("Index","Service");		
		}


	}

    
}
