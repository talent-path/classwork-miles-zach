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
    }
}
