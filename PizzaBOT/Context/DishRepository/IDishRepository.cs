using PizzaBOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBOT.Context.DishRepository
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetDishes();

        Dish GetDishById(int? dishId);

        void AddDish(Dish dish);

        void EditDish(Dish dish);

        void DeleteDish(int disId);

        void Dispose();
    }
}
