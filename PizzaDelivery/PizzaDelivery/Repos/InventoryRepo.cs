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
    }
}
