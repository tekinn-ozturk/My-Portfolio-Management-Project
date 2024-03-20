using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {

        FeatureManager featureManager = new FeatureManager(new EFFeatureRepository()); //=> new  FeatureManager() içine parametre istiyor buda ne olmalı FeatureManager'e gittiğimde ctor'u bi repo argümanı almış.E burda feature'e ait bir repo tanımlamam gerekiyor buda hangisi olacak.??
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
