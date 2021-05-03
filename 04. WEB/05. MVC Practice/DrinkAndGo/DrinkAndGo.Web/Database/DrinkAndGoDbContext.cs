using DrinkAndGo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Database
{
    public class DrinkAndGoDbContext : DbContext
    {
        public DrinkAndGoDbContext(DbContextOptions<DrinkAndGoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
