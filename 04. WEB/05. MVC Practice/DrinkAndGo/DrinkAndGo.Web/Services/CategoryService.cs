using DrinkAndGo.Web.Models;
using DrinkAndGo.Web.Models.Contracts;
using System.Collections.Generic;

namespace DrinkAndGo.Web.Services
{
    public class CategoryService : ICategory
    {
        public ICollection<Category> Categories => new List<Category>
        {
          new Category
          {
           Name = "Alcoholic",
           Description = "All alcoholic drinks"
          },
          new Category
          {
           Name = "Non-alcoholic",
           Description = "All non-alcoholic drinks"
          }};
    }
}
