using DrinkAndGo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
