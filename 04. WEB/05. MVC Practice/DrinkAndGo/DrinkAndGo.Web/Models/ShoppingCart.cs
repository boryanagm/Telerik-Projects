using DrinkAndGo.Web.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrinkAndGo.Web.Models
{
    public class ShoppingCart
    {
        private readonly DrinkAndGoDbContext context;

        public ShoppingCart(DrinkAndGoDbContext context)
        {
            this.context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DrinkAndGoDbContext>();

            string id = session.GetString("Id") ?? Guid.NewGuid().ToString();
            session.SetString("Id", id);

            return new ShoppingCart(context)
            {
                ShoppingCartId = id
            };
        }

        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem = this.context.ShoppingCartItems
                .SingleOrDefault(s => s.Drink.Id == drink.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };

                this.context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            this.context.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem = this.context.ShoppingCartItems
                    .SingleOrDefault(s => s.Drink.Id == drink.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    this.context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            this.context.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            var shoppingCartItems = (ShoppingCartItems = this.context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Drink)
                .ToList());

            return shoppingCartItems;
            //return ShoppingCartItems ??
            //    (ShoppingCartItems = this.context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            //    .Include(s => s.Drink)
            //    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = this.context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);

            this.context.ShoppingCartItems.RemoveRange(cartItems);
            this.context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var shoppingCartTotal = this.context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount).Sum();

            return shoppingCartTotal;
        }
    }
}
