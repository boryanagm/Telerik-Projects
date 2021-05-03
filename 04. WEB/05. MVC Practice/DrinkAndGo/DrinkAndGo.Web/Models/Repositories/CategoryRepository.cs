using DrinkAndGo.Web.Database;
using DrinkAndGo.Web.Models.Contracts;
using System.Collections.Generic;

namespace DrinkAndGo.Web.Models.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly DrinkAndGoDbContext context;

        public CategoryRepository(DrinkAndGoDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> Categories => this.context.Categories;
    }
}
