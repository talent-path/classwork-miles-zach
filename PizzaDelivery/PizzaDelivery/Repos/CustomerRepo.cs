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
    }
}
