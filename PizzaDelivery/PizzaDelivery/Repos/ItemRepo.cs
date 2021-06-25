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
    }
}
