using DrinkAndGo.Web.Models;
using DrinkAndGo.Web.Models.Contracts;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DrinkAndGo.Web.ViewModels;

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

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = this.drinkService.Drinks.OrderBy(d => d.Id);
                currentCategory = "All Drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = this.drinkService.Drinks
                        .Where(d => d.Category.Name.Equals("Alcoholic"))
                        .OrderBy(d => d.Name);
                }
                else
                {
                    drinks = this.drinkService.Drinks
                        .Where(d => d.Category.Name.Equals("Non-alcoholic"))
                        .OrderBy(d => d.Name);
                }
                currentCategory = _category;
            }

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(drinkListViewModel);
        }
    }
}
/*
 ViewBag.Name = "DotNet, How?";

            var viewModel = new DrinkListViewModel();
            viewModel.Drinks = drinkService.Drinks;
            viewModel.CurrentCategory = "DrinkCategory";

            return View(viewModel);
 */