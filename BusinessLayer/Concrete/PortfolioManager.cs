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
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioManager(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioRepository.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioRepository.Delete(t);
        }

        public Portfolio TGetById(int id)
        {
            return _portfolioRepository.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioRepository.GetList();
        }

        public List<Portfolio> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioRepository.Update(t);
            
        }
       
    }
}
