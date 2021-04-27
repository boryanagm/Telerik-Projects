using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using BeerShop.MVC.Models;
using BeerShop.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeerShop.MVC.Controllers
{
	public class HomeController : Controller
	{
        private readonly IUserService userService;
        private readonly IBeerService beerService;

        public HomeController(IUserService userService, IBeerService beerService)
		{
            this.userService = userService;
            this.beerService = beerService;
        }

		public IActionResult Index()
		{
			var beers = this.beerService.GetAll();
			ViewData["Beers"] = beers.ToList();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
