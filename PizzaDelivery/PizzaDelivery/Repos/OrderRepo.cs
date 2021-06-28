using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class OrderRepo
    {
        private PizzaDeliveryDbContext context;

        public OrderRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }

        internal List<Order> FindAll()
        {
            return context.Orders.ToList();
        }

        internal Order FindById(int id)
        {
            return context.Orders.Find(id);
        }

        internal void Remove(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        internal Order Update(Order order)
        {
            context.Attach(order);
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
            return order;
        }

        internal Order Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
    }
}
