using DrinkAndGo.Web.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models.Mocks
{
    public class MockCategory : ICategory
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
