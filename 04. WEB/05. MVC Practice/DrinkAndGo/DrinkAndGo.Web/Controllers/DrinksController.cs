using DrinkAndGo.Web.Models.Contracts;
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
            var drinks = drinkService.Drinks;
            return View(drinks);
        }
    }
}
