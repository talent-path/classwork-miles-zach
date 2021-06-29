using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace PizzaDelivery.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<ItemIngredient> ItemIngredients { get; set; }

        public Ingredient() { }
        public Ingredient(Ingredient copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            //Items = copy.Items.Select(item => new Item(item)).ToList();
        }
    }
}