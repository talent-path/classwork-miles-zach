using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class AddressRepo 
    {
        private PizzaDeliveryDbContext context;
        public AddressRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }
    }
}
