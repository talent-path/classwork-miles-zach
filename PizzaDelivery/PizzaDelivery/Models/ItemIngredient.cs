using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class ItemIngredient
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public Item Item { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
        
    }
}
