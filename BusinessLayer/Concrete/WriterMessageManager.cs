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
    public class WriterMessageManager : IWriterMessageService
    {
        private readonly IWriterMessageRepository _writerMessageRepository;

        public WriterMessageManager(IWriterMessageRepository writerMessageRepository)
        {
            _writerMessageRepository = writerMessageRepository;
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageRepository.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageRepository.Delete(t);
        }

        public WriterMessage TGetById(int id)
        {
           return _writerMessageRepository.GetById(id); 
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessageRepository.GetList();
        }

        public List<WriterMessage> TGetListByFilter(string p)
        {
            return _writerMessageRepository.GetByFilter(x=>x.Receiver==p);
        }

        public List<WriterMessage> TGetListReceiverMessage(string receiverMail)
        {
            return _writerMessageRepository.GetByFilter(x => x.Receiver == receiverMail);
        }

        public List<WriterMessage> TGetListSenderMessage(string senderMail)
        {
            return _writerMessageRepository.GetByFilter(x => x.Sender == senderMail);
        }

        public int TGetReceiverMessageCount(int id)
        {
           return _writerMessageRepository.GetByReceiverMessageCount(id);
        }

        public void TUpdate(WriterMessage t)
        {
            _writerMessageRepository.Update(t);
        }
    }
}
