using PizzaDelivery.Models;
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

        internal void Remove(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        internal Ingredient Update(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        internal Ingredient Add(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        internal List<Ingredient> FindAll()
        {
            throw new NotImplementedException();
        }

        internal Ingredient FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
