using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models.Contracts
{
    public interface IDrink
    {
        // ICollection vs IEnumerable
        ICollection<Drink> Drinks { get; set; }
        ICollection<Drink> PreferredDrinks { get; set; }
        Drink GetDrinkById(int drinkId);
    }
}
