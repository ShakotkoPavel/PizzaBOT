using PizzaBOT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaBOT.Context
{
    public class MyInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Dish dish1 = new Dish { Name = "Carbonara", Price = 120, Description = "Italian pizza" };
            Dish dish2 = new Dish { Name = "BBQ pizza", Price = 150, Description = "Pepper pizza" };
            Dish dish3 = new Dish { Name = "Chicken pizza", Price = 135, Description = "With chicken meat" };
            Dish dish4 = new Dish { Name = "Cheese pizza", Price = 125, Description = "With French cheese" };

            context.Dishes.AddRange(new List<Dish> { dish1, dish2, dish3, dish4 });
            context.SaveChanges();
        }
    }

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {

        }

        static DataContext()
        {
            Database.SetInitializer(new MyInitializer());
            DataContext db = new DataContext();
            db.Database.Initialize(true);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}