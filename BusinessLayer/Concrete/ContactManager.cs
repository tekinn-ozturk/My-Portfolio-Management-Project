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
	public class ContactManager : IContactService
	{
		private readonly IContactRepository _contactRepository;

		public ContactManager(IContactRepository contactRepository)
        {
			_contactRepository = contactRepository;
		}
        public void TAdd(Contact t)
		{
			_contactRepository.Insert(t);
		}

		public void TDelete(Contact t)
		{
			_contactRepository.Delete(t);
		}

		public Contact TGetById(int id)
		{
			return _contactRepository.GetById(id);
		}

		public List<Contact> TGetList()
		{
			return _contactRepository.GetList();
		}

        public List<Contact> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
		{
			_contactRepository.Update(t);
		}
	}
}
