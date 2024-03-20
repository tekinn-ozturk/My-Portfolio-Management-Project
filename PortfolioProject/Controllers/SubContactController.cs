using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class SubContactController : Controller
    {
        private readonly IContactService _contactService;

        public SubContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact c)
        {
            _contactService.TUpdate(c);
            return RedirectToAction("Index","Default");
        }
    }
}
