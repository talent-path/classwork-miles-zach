using System.Collections.Generic;

namespace PizzaDelivery.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public List<Order> Orders { get; set; }

        public Customer() { }
        public Customer(Customer copy)
        {
            Id = copy.Id;
            Name = copy.Name;
        }

    }
}