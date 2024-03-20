using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFWriterMessageRepository : GenericRepository<WriterMessage>, IWriterMessageRepository
    {
        
        public int GetByReceiverMessageCount(int id)
        {

            using (var c=new Context())
            {
                var values = c.Users.Find(id);
                int receiverMessage = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
                return receiverMessage;
            }
        }
    }
}
