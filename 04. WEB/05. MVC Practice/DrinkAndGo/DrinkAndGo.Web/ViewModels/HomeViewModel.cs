using DrinkAndGo.Web.Models;
using System.Collections.Generic;

namespace DrinkAndGo.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}
