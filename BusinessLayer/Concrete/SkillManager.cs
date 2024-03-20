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
	public class SkillManager : ISkillService
	{
		private readonly ISkillRepository _skillRepository;

		public SkillManager(ISkillRepository skillRepository)
        {
			_skillRepository = skillRepository;
		}
        public void TAdd(Skill t)
		{
			_skillRepository.Insert(t);
		}

		public void TDelete(Skill t)
		{
			_skillRepository.Delete(t);
		}

		public Skill TGetById(int id)
		{
			return _skillRepository.GetById(id);
		}

        public int TGetCountSkill()
        {
            return _skillRepository.GetCountSkill();
        }

        public List<Skill> TGetList()
		{
			return _skillRepository.GetList();
		}

        public List<Skill> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skill t)
		{
			_skillRepository.Update(t);
		}
	}
}
