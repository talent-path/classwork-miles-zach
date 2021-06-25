using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class ContactRepo
    {
        private PizzaDeliveryDbContext context;

        public ContactRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }
    }
}
