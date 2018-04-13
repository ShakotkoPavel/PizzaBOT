using PizzaBOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaBOT.Context.OrderRepository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
    }
}