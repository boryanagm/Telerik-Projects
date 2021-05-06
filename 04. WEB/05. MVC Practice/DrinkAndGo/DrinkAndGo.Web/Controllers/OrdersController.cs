using DrinkAndGo.Web.Models;
using DrinkAndGo.Web.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;

        public OrdersController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Checkout(Order order)
        //{
        //    var items = this.shoppingCart.GetShoppingCartItems();

        //    this.shoppingCart.ShoppingCartItems = items;

        //    if (this.shoppingCart.ShoppingCartItems.Count == 0)
        //    {
        //        ModelState.AddModelError("", "Your cart is empty, add some drinks first");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        this.orderRepository.CreateOrder(order);
        //        this.shoppingCart.ClearCart();

        //        return RedirectToAction("Checkoutcomplete");
        //    }
        //}

        public IActionResult Checkoutcomplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}
