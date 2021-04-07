using LayeredArchitecture.Data.Models;
using System;
using System.Collections.Generic;

namespace Data
{
    public static class Database
    {
        static Database()
        {
            Beers = new List<Beer>();

            Users = new List<User>();

            SeedData();
        }

        public static List<Beer> Beers { get; set; }
        public static List<User> Users { get; set; }

        private static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    Name = "London Pride",
                    Abv = 4.7
                },
                new Beer
                {
                    Id = 2,
                    Name = "Frontier",
                    Abv = 4.2
                },
                new Beer
                {
                    Id = 3,
                    Name = "Honey Dew",
                    Abv = 4.8
                }
            });

            Users.AddRange(new List<User>
            {
                new User
                {
                   Id = 1,
                   Name = "Miguel Hernandez",
                   Email = "miguel.h@gmail.com"
                },
                new User
                {
                   Id = 2,
                   Name = "Xavi Blanco",
                   Email = "x.blanco@gmail.com"
                },
                new User
                {
                   Id = 3,
                   Name = "Meritxell Lorente",
                   Email = "merilorente@gmail.com"
                }
            });
        }
    }
}
