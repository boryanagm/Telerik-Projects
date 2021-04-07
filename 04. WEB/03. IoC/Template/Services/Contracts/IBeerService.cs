using LayeredArchitecture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayeredArchitecture.Services.Contracts
{
    public interface IBeerService
    {
        Beer Get(int id);
        IEnumerable<Beer> GetAll();
        Beer Create(Beer beer);
        Beer Update(int id, Beer beer);
        bool Delete(int id);
    }
}
