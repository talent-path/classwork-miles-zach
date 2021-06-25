namespace PizzaDelivery.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public Contact() { }
        public Contact(Contact copy)
        {
            Id = copy.Id;
            Phone = copy.Phone;
            Email = copy.Email;
            Address = new Address(copy.Address);
        }
    }
}