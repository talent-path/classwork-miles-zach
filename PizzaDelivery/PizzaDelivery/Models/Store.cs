using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Store
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        public List<Inventory> Inventory { get; set; }
        public List<Order> Orders { get; set; }
    }
}
