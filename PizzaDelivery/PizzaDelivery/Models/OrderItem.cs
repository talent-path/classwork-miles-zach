using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class OrderItem
    {
        //[Key, Column(Order = 0), ForeignKey("Order")]
        public int OrderId { get; set; }
        //[Key, Column(Order = 1), ForeignKey("Item")]
        public int ItemId { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
