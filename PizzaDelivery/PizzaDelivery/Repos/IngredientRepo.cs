using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class IngredientRepo
    {
        private PizzaDeliveryDbContext context;

        public IngredientRepo(PizzaDeliveryDbContext context)
        {
            this.context = context;
        }
    }
}
