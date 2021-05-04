using DrinkAndGo.Web.Models;
using DrinkAndGo.Web.Models.Contracts;
using DrinkAndGo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IDrinkRepository drinkRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartsController(IDrinkRepository drinkRepository, ShoppingCart shoppingCart)
        {
            this.drinkRepository = drinkRepository;
            this.shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = this.shoppingCart.GetShoppingCartItems();
            this.shoppingCart.ShoppingCartItems = items;

            var shopingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShoppingCartTotal()
            };

            return View(shopingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = this.drinkRepository.Drinks.FirstOrDefault(d => d.Id == drinkId);

            if (selectedDrink != null)
            {
                this.shoppingCart.AddToCart(selectedDrink, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = this.drinkRepository.Drinks.FirstOrDefault(d => d.Id == drinkId);

            if (selectedDrink != null)
            {
                this.shoppingCart.RemoveFromCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }
    }
}
