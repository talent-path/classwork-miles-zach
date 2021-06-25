using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Repos
{
    public class PizzaDeliveryDbContext : DbContext
    {
       public DbSet<Store> Stores { get; set; }
       public DbSet<Order> Order { get; set; }
       public DbSet<Customer> Customer { get; set; }
       public DbSet<Inventory> Inventory { get; set; }
       public DbSet<Item> Item { get; set; }
       public DbSet<Contact> Contact { get; set; }
       public DbSet<Address> Address { get; set; }
       public DbSet<Ingredient> Ingredient { get; set; }
       public PizzaDeliveryDbContext(DbContextOptions<PizzaDeliveryDbContext> options) : base(options) { }
    }
}
