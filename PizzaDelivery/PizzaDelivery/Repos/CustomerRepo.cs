using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class CustomerRepo
    {
        private PizzaDeliveryDbContext context;

        public CustomerRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }
       
        internal Customer FindById(int id)
        {
            return context.Customers
                .Where(customer => customer.Id == id)
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.OrderItems)
                .FirstOrDefault();
        }

        internal Customer Update(Customer customer)
        {
            context.Attach(customer);
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            return customer;
        }

        internal Customer Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        internal List<Customer> FindAll()
        {
            return context.Customers
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.OrderItems)
                .ToList();
        }

        internal void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
