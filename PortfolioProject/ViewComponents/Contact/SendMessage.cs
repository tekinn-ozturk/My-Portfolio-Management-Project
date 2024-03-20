using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Contact
{
	//ViewComponent'lerde ! den fazla Invoke methodu çağrılmadığı için PartialView kullandık.Çünkü Message'lar için HttpGet ve HttpPost işlemleri gerekiyor.
	public class SendMessage : ViewComponent
	{

		MessageManager messageManager = new MessageManager(new EFMessageRepository());

		[HttpGet]
		public IViewComponentResult Invoke()
		{
			//burada herhangi bir listeleme veyahut başka bişey yok çünkü herhangi bir veri getirilmeyecek buraya
			return View();
		}

		//[HttpPost]
		//public IViewComponentResult Invoke(Message p)
		//{
		//	//Kulllanıcı bana mesaj göndermek istediğinde benim istediğim onun dolduracağı bilgiler otomatik veritabanına kaydolacak mail,content,name.
		//	//Geriye kalan özellikler Date, status onları da ben veriyorum.
		//	//Burada mapper tarzı bişey yapabilirim.
		//	//Ayrıca Dependency Injection 'da gerçekleştirebilirim.

		//	p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
		//	p.Status = true;
		//	messageManager.TAdd(p);
		//	return View();
		//}
	}
}
