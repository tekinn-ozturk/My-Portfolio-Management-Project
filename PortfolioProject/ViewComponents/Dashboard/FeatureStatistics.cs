﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.Message.Where(x => x.Status == false).Count();
            ViewBag.v3 = c.Message.Where(x => x.Status == true).Count();
            ViewBag.v4 = c.Experiences.Count();
            
            return View();
        }

    }
}
