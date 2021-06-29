using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
        public Ingredient Ingredient { get; set; }
        public Store Store { get; set; }

        public Inventory() { }
        public Inventory(Inventory copy)
        {
            Id = copy.Id;
            Quantity = copy.Quantity;
            Ingredient = new Ingredient(copy.Ingredient);
        }
    }
}
