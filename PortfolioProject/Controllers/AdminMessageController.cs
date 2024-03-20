using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService;

        public AdminMessageController(IWriterMessageService writerMessageService)
        {
                
            _writerMessageService = writerMessageService;
         
        }

        public IActionResult ReceiverMessageList()
        {
            string p = "admin@gmail.com";
            var values = _writerMessageService.TGetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            string p = "admin@gmail.com";
            var values = _writerMessageService.TGetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetail(int id)
        {
            var values = _writerMessageService.TGetById(id);
            return View(values);
        }

        public IActionResult AdminMessageDeleteReceiver(int id)
        {

            var values = _writerMessageService.TGetById(id);
            _writerMessageService.TDelete(values);
            return RedirectToAction("ReceiverMessageList");



        }

        public IActionResult AdminMessageDeleteSender(int id)
        {
            var values = _writerMessageService.TGetById(id);
           
            _writerMessageService.TDelete(values);
            return RedirectToAction("SenderMessageList");



        }
        public IActionResult AdminMessageSend()
        {
            
            return View();
        }



        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            Context c = new();
            //Users.Where(x => x.Email == p.Receiver) Kullanıcı UI'da Alıcı maili giriyor ya onu Database'deki mailler ile eşleme yapıyoruz.Kullanıcının girdiği mail adresini databasede bulup o verideki ad-soyad verilerini birleştirip userNameSurname değişkenine atıyoruz.
            var userNameSurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname;
            _writerMessageService.TAdd(p);
            
            return RedirectToAction("SenderMessageList");  
        }

       
        
    }
}
