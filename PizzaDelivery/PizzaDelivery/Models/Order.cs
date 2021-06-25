using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public bool Delivered { get; set; }
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }

        public Order() { }
        public Order(Order copy)
        {
            Id = copy.Id;
            TimeIn = copy.TimeIn;
            TimeOut = copy.TimeOut;
            Delivered = copy.Delivered;
            Customer = new Customer(copy.Customer);
            Items = copy.Items.Select(item => new Item(item)).ToList();
        }
    }
}
