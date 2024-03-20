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
    public class EFAnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        public int GetCountAnnouncement()
        {
           using(var c=new Context())
            {
                int announcementCount = c.Announcements.Count();
                return announcementCount;
            }
        }
    }
}
