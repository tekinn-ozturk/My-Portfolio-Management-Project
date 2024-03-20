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
	public class MessageManager : IMessageService
	{
		private readonly IMessageRepository _messageRepository;

		public MessageManager(IMessageRepository messageRepository)
        {
			_messageRepository = messageRepository;
		}
        public void TAdd(Message t)
		{
			_messageRepository.Insert(t);
		}

		public void TDelete(Message t)
		{
			_messageRepository.Delete(t);
		}

		public Message TGetById(int id)
		{
			return _messageRepository.GetById(id);
		}

		public List<Message> TGetList()
		{
			return _messageRepository.GetList();
		}

        public List<Message> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
		{
			_messageRepository.Update(t);
		}
	}
}
