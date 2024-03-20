using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterAppUser> _userManager;

        public MessageController(IWriterMessageService writerMessageService, UserManager<WriterAppUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.TGetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.TGetListSenderMessage(p);
            return View(messageList);
        }

        public IActionResult MessageDetails(int id)
        {
            WriterMessage message = _writerMessageService.TGetById(id);
            return View(message);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }



        /*IEnumerable tipi veriyi önce belleğe atıp ardından bellekteki bu veri üzerinden belirtilen koşulları çalıştırır ve veriye uygular.

          IQueryable tipinde ise belirtilen sorgular direk olarak server üzerinde çalıştırılır ve dönüş sağlar. */

        /* IEnumerable<T>: Collections hiyerarşisinin en tepesindedir. ICollection, IList, IDictionary yapılarını kapsar.
           ICollection<T>: IEnumerablenin altında yaşar, IList ve IDictionary yapılarını kapsar.*/
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            string surName = values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;

            Context c = new();
            //Users.Where(x => x.Email == p.Receiver) Kullanıcı UI'da Alıcı maili giriyor ya onu Database'deki mailler ile eşleme yapıyoruz.Kullanıcının girdiği mail adresini databasede bulup o verideki ad-soyad verilerini birleştirip userNameSurname değişkenine atıyoruz.
            var userNameSurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            //Select->Elemanı seçer ve o elemanın Name ve Surname özelliklerini birleştirerek yeni bir string oluşturur ardından  userNameSurname deişkenine atarız
            p.ReceiverName = userNameSurname;

            _writerMessageService.TAdd(p);
            return RedirectToAction("SenderMessage");
            //RedirecToAction'ı unutma 1 saat uğraştırdı.
        }

    }
}
