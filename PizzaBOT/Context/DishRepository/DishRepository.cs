using PizzaBOT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PizzaBOT.Context.DishRepository
{
    public class DishRepository : IDishRepository, IDisposable
    {
        private DataContext db;

        //public DishRepository(DataContext dataContext)
        //{
        //    db = dataContext;
        //}

        public DishRepository()
        {
            db = new DataContext();
        }

        public async Task<IEnumerable<Dish>> GetDishes()
        {
            return await db.Dishes.ToListAsync();
        }

        public Dish GetDishById(int? dishId)
        {
            return db.Dishes.Find(dishId);
        }

        public void AddDish(Dish dish)
        {
            db.Dishes.Add(dish);
            db.SaveChanges();
        }

        public void EditDish(Dish dish)
        {
            if (dish != null)
            {
                db.Entry(dish).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteDish(int dishId)
        {
            var dish = db.Dishes.Find(dishId);
            if (dish != null)
            {
                db.Dishes.Remove(dish);
                db.SaveChanges();
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}