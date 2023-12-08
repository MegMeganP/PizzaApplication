using Microsoft.EntityFrameworkCore;
using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConnectionString == null)
            {
                ConnectionString = "Data Source=megansqlserver2022.database.windows.net,1433;Initial Catalog=PizzaApplication;Integrated Security=False;User ID=MeganSqlServer;Password=M3ganSqlServer;Encrypt=True;TrustServerCertificate=False;";
            }

            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Topping>().HasIndex(p => p.ToppingName).IsUnique();
            modelBuilder.Entity<Pizza>().HasIndex(p => p.Name).IsUnique();
        }



    }
}
