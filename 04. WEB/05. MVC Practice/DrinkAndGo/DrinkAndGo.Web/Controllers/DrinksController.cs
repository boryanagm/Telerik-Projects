using DrinkAndGo.Web.Models.Contracts;
using DrinkAndGo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ICategoryRepository categoryService;
        private readonly IDrinkRepository drinkService;

        public DrinksController(ICategoryRepository categoryService, IDrinkRepository drinkService)
        {
            this.categoryService = categoryService;
            this.drinkService = drinkService;
        }

        public IActionResult List()
        {
            ViewBag.Name = "DotNet, How?";

            var viewModel = new DrinkListViewModel();
            viewModel.Drinks = drinkService.Drinks;
            viewModel.CurrentCategory = "DrinkCategory";

            return View(viewModel);
        }
    }
}
