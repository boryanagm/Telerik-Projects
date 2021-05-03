using DrinkAndGo.Web.Models.Contracts;
using DrinkAndGo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ICategory categoryService;
        private readonly IDrink drinkService;

        public DrinksController(ICategory categoryService, IDrink drinkService)
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
