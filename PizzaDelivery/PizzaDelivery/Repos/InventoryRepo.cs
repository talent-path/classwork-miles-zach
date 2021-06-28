using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class InventoryRepo
    {
        private PizzaDeliveryDbContext context;

        public InventoryRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }

        internal Inventory Update(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        internal Inventory Add(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        internal Inventory FindById(int id)
        {
            throw new NotImplementedException();
        }

        internal List<Inventory> FindAll()
        {
            throw new NotImplementedException();
        }

        internal void Remove(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
