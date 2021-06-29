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
            return context.Orders
                .Include(order => order.Customer)
                .Include(order => order.Store)
                .Include(order => order.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToList();
        }

        internal Order FindById(int id)
        {
            return context.Orders
                .Where(order => order.Id == id)
                .Include(order => order.Customer)
                .Include(order => order.Store)
                .Include(order => order.OrderItems)
                .ThenInclude(oi => oi.Item)
                .FirstOrDefault();
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
            context.Customers.Attach(order.Customer);
            context.Stores.Attach(order.Store);
            foreach (var item in order.OrderItems)
                context.OrderItems.Attach(item);
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
    }
}
