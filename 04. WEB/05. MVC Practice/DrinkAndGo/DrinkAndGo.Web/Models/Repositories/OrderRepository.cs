using DrinkAndGo.Web.Database;
using DrinkAndGo.Web.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DrinkAndGoDbContext context;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(DrinkAndGoDbContext context, ShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.UtcNow;
            this.context.Orders.Add(order);
            this.context.SaveChanges();

            var shoppingCartItems = this.shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    DrinkId = item.Drink.Id,
                    OrderId = order.OrderId,
                    Price = item.Drink.Price
                };

                this.context.OrderDetails.Add(orderDetail);
            }

            this.context.SaveChanges();
        }
    }
}
