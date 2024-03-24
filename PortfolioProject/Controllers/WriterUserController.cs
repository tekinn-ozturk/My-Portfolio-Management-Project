using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioProject.Controllers
{
    public class WriterUserController : Controller
    {
        private readonly IWriterUserService _writerUserService;

        public WriterUserController(IWriterUserService writerUserService)
        {
            _writerUserService = writerUserService;
        }

        public IActionResult Index()
        {


            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(_writerUserService.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterAppUser p)
        {
            _writerUserService.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);    

        }

            
    }
 
}
