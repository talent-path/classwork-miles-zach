using Microsoft.EntityFrameworkCore;
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
            context.Ingredients.Remove(ingredient);
            context.SaveChanges();
        }

        internal Ingredient Update(Ingredient ingredient)
        {
            context.Attach(ingredient);
            context.Entry(ingredient).State = EntityState.Modified;
            context.SaveChanges();
            return ingredient;
        }

        internal Ingredient Add(Ingredient ingredient)
        {
            context.Ingredients.Add(ingredient);
            context.SaveChanges();
            return ingredient;
        }

        internal List<Ingredient> FindAll()
        {
            return context.Ingredients
                .ToList();
        }

        internal Ingredient FindById(int id)
        {
            return context.Ingredients
                .Where(ingredient => ingredient.Id == id)
                .FirstOrDefault();
        }
    }
}
