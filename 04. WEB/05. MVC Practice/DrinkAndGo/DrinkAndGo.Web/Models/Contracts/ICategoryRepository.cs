using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Models.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
