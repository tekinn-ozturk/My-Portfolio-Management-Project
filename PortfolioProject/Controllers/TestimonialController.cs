using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }

        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TAdd(testimonial);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return RedirectToAction("Index");
        }


        public IActionResult EditTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            return View(values);


        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial t)
        {

            _testimonialService.TUpdate(t);
            return RedirectToAction("Index");


        }

    }
}
