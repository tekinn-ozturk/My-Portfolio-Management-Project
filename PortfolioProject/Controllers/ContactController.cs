using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        //Default sayfasından iletişim alanından gelen iletişimlerin yönetildiği bölüm.
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.TGetList();
            return View(values);
        }

       
        public IActionResult DeleteContact(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values);
            return RedirectToAction("Index");   
        }

        public IActionResult ContactDetails(int id)
        {
            var values = _messageService.TGetById(id);
            return View(values);    
        }
    }
}
