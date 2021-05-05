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
    }
}
