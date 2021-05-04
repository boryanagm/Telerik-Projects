using DrinkAndGo.Web.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
