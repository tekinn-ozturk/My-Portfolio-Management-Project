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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementManager(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public void TAdd(Announcement t)
        {
            _announcementRepository.Insert(t);  
        }

        public void TDelete(Announcement t)
        {
            _announcementRepository.Delete(t);
        }

        public Announcement TGetById(int id)
        {
            return _announcementRepository.GetById(id); 
        }

        public int TGetCountAnnouncement()
        {
            return _announcementRepository.GetCountAnnouncement();
        }

        public List<Announcement> TGetList()
        {
            return _announcementRepository.GetList();
        }

        public List<Announcement> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
        {
           _announcementRepository.Update(t);   
        }
    }
}
