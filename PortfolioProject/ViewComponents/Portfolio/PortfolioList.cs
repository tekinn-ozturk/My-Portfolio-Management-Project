﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Portfolio
{
	public class PortfolioList : ViewComponent
	{
		 PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioRepository());
		public IViewComponentResult Invoke()
		{
			var values = portfolioManager.TGetList();
			return View(values);
		}
	}

}
