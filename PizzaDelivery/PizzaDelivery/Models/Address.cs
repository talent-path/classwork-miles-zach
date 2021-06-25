namespace PizzaDelivery.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address() { }
        public Address(Address copy)
        {
            Id = copy.Id;
            Street = copy.Street;
            City = copy.City;
            State = copy.State;
            Zip = copy.Zip;
        }
    }
}