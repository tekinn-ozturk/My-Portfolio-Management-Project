using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFSkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public int GetCountSkill()
        {
            using (var c = new Context())
            {
                int skillCount = c.Skills.Count();
                return skillCount;
            }
        }
    }
}
