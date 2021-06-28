using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class ItemRepo
    {
        private PizzaDeliveryDbContext context;

        public ItemRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }

        internal void Remove(Item item)
        {
            throw new NotImplementedException();
        }

        internal Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        internal Item Update(Item item)
        {
            throw new NotImplementedException();
        }

        internal List<Item> FindAll()
        {
            throw new NotImplementedException();
        }

        internal Item Add(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
