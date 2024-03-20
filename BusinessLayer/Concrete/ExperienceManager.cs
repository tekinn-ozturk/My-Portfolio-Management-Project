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
	public class ExperienceManager : IExperienceService
	{
		private readonly IExperienceRepository _experienceRepository;

		public ExperienceManager(IExperienceRepository experienceRepository)
        {
			_experienceRepository = experienceRepository;
		}

		public void TAdd(Experience t)
		{
			_experienceRepository.Insert(t);
		}

		public void TDelete(Experience t)
		{
			_experienceRepository.Delete(t);
		}

		public Experience TGetById(int id)
		{
			return _experienceRepository.GetById(id);
		}

		public List<Experience> TGetList()
		{
			return _experienceRepository.GetList();
		}

        public List<Experience> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience t)
		{
		   _experienceRepository.Update(t);	
		}
	}
}
