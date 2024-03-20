using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Testimonial
{
	public class TestimonialList : ViewComponent
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialRepository());
		public IViewComponentResult Invoke()
		{
			var values = testimonialManager.TGetList();
			return View(values);
		}
	}
}
