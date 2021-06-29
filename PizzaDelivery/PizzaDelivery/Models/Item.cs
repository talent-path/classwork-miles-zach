﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaDelivery.Models
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<ItemIngredient> ItemIngredients { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Item() { }
        public Item(Item copy)
        {
            Id = copy.Id;
            Name = copy.Name;

        }
    }
}