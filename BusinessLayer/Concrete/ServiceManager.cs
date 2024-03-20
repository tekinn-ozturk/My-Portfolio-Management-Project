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
	public class ServiceManager : IServiceService
	{
		private readonly IServiceRepository _serviceRepository;

		public ServiceManager(IServiceRepository serviceRepository)
        {
			_serviceRepository = serviceRepository;
		}
        public void TAdd(Service t)
		{
			_serviceRepository.Insert(t);
		}

		public void TDelete(Service t)
		{
			_serviceRepository.Delete(t);
		}

		public Service TGetById(int id)
		{
			return _serviceRepository.GetById(id);
		}

		public List<Service> TGetList()
		{
			return _serviceRepository.GetList();
		}

        public List<Service> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Service t)
		{
			_serviceRepository.Update(t);
		}
	}
}
