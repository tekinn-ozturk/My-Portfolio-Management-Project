using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class TestimonialManager : ITestimonialService
	{
		private readonly ITestimonialRepository _testimonialRepository;

		public TestimonialManager(ITestimonialRepository testimonialRepository)
        {
			_testimonialRepository = testimonialRepository;
		}

		public void TAdd(Testimonial t)
		{
			_testimonialRepository.Insert(t);
		}

		public void TDelete(Testimonial t)
		{
			_testimonialRepository.Delete(t);
		}

		public Testimonial TGetById(int id)
		{
			return _testimonialRepository.GetById(id);
		}

		public List<Testimonial> TGetList()
		{
			return _testimonialRepository.GetList();
		}

        public List<Testimonial> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
		{
			_testimonialRepository.Update(t);
		}
	}
}
