using System;
namespace VendingMachineData.Models
{
    public class Candy : ICandy
    {
        public Candy(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }

        public string Name { get; }
        public decimal Price { get; }
        public int Qty { get; set; }

        public override string ToString()
        {
            return $"{Name},{Price},{Qty}";
        }
    }
}
