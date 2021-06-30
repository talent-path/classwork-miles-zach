using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public decimal Stock { get; set; }
        public string Units { get; set; }
        
        public Ingredient Ingredient { get; set; }
        public Store Store { get; set; }
        

        public Inventory() { }
        public Inventory(Inventory copy)
        {
            Id = copy.Id;
            Stock = copy.Stock;
            Ingredient = new Ingredient(copy.Ingredient);
        }
    }
}
