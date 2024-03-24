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
    public class WriterUserManager : IWriterUserService
    {
        private readonly IWriterUserRepository _writerRepository;

        public WriterUserManager(IWriterUserRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public void TAdd(WriterAppUser t)
        {
            _writerRepository.Insert(t);    
        }

        public void TDelete(WriterAppUser t)
        {
            _writerRepository.Delete(t);
        }

        public WriterAppUser TGetById(int id)
        {
           return _writerRepository.GetById(id);
        }

        public List<WriterAppUser> TGetList()
        {
            return _writerRepository.GetList();
        }

        public List<WriterAppUser> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterAppUser t)
        {
            _writerRepository.Update(t);
        }
    }
}