using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models.Contracts
{
    public interface IDrink
    {
        // ICollection vs IEnumerable
        ICollection<Drink> Drinks { get; }
        ICollection<Drink> PreferredDrinks { get; }
        Drink GetDrinkById(int drinkId);
    }
}
