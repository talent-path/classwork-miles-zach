namespace PizzaDelivery.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }

        public Customer() { }
        public Customer(Customer copy)
        {
            Id = copy.Id;
            FirstName = copy.FirstName;
            LastName = copy.LastName;
            Contact = new Contact(copy.Contact);
        }

    }
}