using PizzaBOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaBOT.Context.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext db;

        public OrderRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return db.Orders;
        }
    }
}