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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureManager(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public void TAdd(Feature t)
        {
            _featureRepository.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureRepository.Delete(t);
        }

        public Feature TGetById(int id)
        {
            return _featureRepository.GetById(id);  
        }

        public List<Feature> TGetList()
        {
            return _featureRepository.GetList();
        }

        public List<Feature> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
            _featureRepository.Update(t);
        }
    }
}
