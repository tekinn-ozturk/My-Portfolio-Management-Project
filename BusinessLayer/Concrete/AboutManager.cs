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
	public class AboutManager : IAboutService
	{
		private readonly IAboutRepository _aboutRepository;

		public AboutManager(IAboutRepository aboutRepository)
        {
			_aboutRepository = aboutRepository;
		}
        public void TAdd(About t)
		{
			_aboutRepository.Insert(t);	
		}

		public void TDelete(About t)
		{
			_aboutRepository.Delete(t);
		}

		public About TGetById(int id)
		{
			return _aboutRepository.GetById(id);
		}

		public List<About> TGetList()
		{
			return _aboutRepository.GetList();
		}

        public List<About> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
		{
		   _aboutRepository.Update(t);
		}
	}
}
