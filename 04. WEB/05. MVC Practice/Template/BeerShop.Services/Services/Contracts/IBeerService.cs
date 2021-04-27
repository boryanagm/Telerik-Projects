using BeerShop.Data.Models;
using System.Collections.Generic;

namespace BeerShop.Services.Contracts
{
    public interface IBeerService
    {
        Beer Get(int id);
        IEnumerable<Beer> GetAll();
        Beer Create(Beer beer);
        Beer Update(int id, string name);
        bool Delete(int id);
    }
}
