using DrinkAndGo.Web.Database;
using DrinkAndGo.Web.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrinkAndGo.Web.Models.Repositories
{
    public class DrinkRepository : IDrink
    {
        private readonly DrinkAndGoDbContext context;

        public DrinkRepository(DrinkAndGoDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Drink> Drinks => this.context.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => this.context.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => this.context.Drinks.FirstOrDefault(d => d.Id == drinkId);
    }
}
    