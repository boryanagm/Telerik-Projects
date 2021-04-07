using Data;
using LayeredArchitecture.Data.Models;
using LayeredArchitecture.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class BeerService : IBeerService
    {
        public Beer Get(int id)
        {
            var beer = Database.Beers
                .FirstOrDefault(b => b.Id == id)
                ?? throw new ArgumentNullException();

            return beer;
        }

        public IEnumerable<Beer> GetAll()
        {
            var beers = Database.Beers;

            return beers;
        }

        public Beer Create(Beer beer)
        {
            Database.Beers.Add(beer);

            return beer;
        }

        public Beer Update(int id, Beer model)
        {
            var beer = Database.Beers
                .FirstOrDefault(b => b.Id == id)
                ?? throw new ArgumentNullException();

            beer.Name = model.Name;

            return beer;
        }

        public bool Delete(int id)
        {
            var beer = Database.Beers
                .FirstOrDefault(b => b.Id == id);

            return Database.Beers.Remove(beer);
        }
    }
}
