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
            throw new NotImplementedException();
        }

        internal void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        internal Customer Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        internal Customer Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        internal List<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        internal void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
