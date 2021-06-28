using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public Ingredient Ingredient { get; set; }

        public Inventory() { }
        public Inventory(Inventory copy)
        {
            Id = copy.Id;
            Stock = copy.Stock;
            Ingredient = new Ingredient(copy.Ingredient);
        }
    }
}
