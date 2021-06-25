using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PizzaDelivery.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }

        public Item() { }
        public Item(Item copy)
        {
            Id = copy.Id;
            Name = copy.Name;

        }
    }
}