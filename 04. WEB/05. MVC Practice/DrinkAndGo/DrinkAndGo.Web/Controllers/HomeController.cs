using DrinkAndGo.Web.Models.Contracts;
using DrinkAndGo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository drinkRepository;

        // private readonly ILogger<HomeController> _logger;

        public HomeController(IDrinkRepository drinkRepository) // ILogger<HomeController> logger
        {
            this.drinkRepository = drinkRepository;
            // _logger = logger;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = this.drinkRepository.PreferredDrinks
            };

            return View(homeViewModel);
        }

       
    }
}
