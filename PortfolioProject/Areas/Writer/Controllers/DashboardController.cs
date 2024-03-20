using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterAppUser> _userManager;

        private readonly IWriterMessageService _messageService;
        private readonly IAnnouncementService _announcementService;
        private readonly ISkillService _skillService;

        public DashboardController(UserManager<WriterAppUser> userManager, IAnnouncementService announcementService, ISkillService skillService, IWriterMessageService messageService)
        {
            _userManager = userManager;

            _announcementService = announcementService;
            _skillService = skillService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = user.Name;
            ViewBag.v2 = user.Surname;


            //İstastistikleri getir
            //int msg =  _userMessageService.TGetCountUserMessage();
            ViewBag.m1 = _messageService.TGetReceiverMessageCount(user.Id);


            ViewBag.m2 = _announcementService.TGetCountAnnouncement();
            Context c = new Context();

            ViewBag.m3 = c.Users.Count();
            ViewBag.m4 = _skillService.TGetCountSkill();

            //Hava Durumu API Çekme
            string apiKey = "a836873d6e6110f79efc05c8207ac850";
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid={apiKey}";
            XDocument doc = XDocument.Load(connection);
            var celcius = (doc.Descendants("temperature").ElementAt(0).Attribute("value").Value);
            decimal celciusDec = Convert.ToDecimal(celcius,CultureInfo.InvariantCulture);
            decimal celciusInt = Math.Round(celciusDec);
            ViewBag.a = celciusInt;



            //Descendants metodu ise XML dosya içerisindeki hangi elementi seçiyorsan burada temperature'yi seçtin onun içine ulaşıyor.
            //ElementAt metodu, bir koleksiyonda belirtilen dizindeki öğeyi almak için kullanılır. 
            //Attribute metodu ise hangi attribute'yi seçmek için kullanılır.


            return View();
        }
    }
}
