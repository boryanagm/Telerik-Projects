using DrinkAndGo.Web.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DrinkAndGo.Web.Models
{
    public class ShoppingCart
    {
        private readonly DrinkAndGoDbContext context;

        public ShoppingCart(DrinkAndGoDbContext context)
        {
            this.context = context;
        }
        public string Id { get; set; }
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
                Id = id
            };
        }
    }
}
