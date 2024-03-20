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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaManager(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaRepository.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaRepository.Delete(t);
        }

        public SocialMedia TGetById(int id)
        {
           return _socialMediaRepository.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaRepository.GetList();
        }

        public List<SocialMedia> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
           _socialMediaRepository.Update(t);    
        }
    }
}
