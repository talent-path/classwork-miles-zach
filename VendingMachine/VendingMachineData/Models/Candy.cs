using System;
namespace VendingMachineData.Models
{
    public class Candy : ICandy
    {

        public string Name { get; }
        public decimal Price { get; }
        public int Qty { get; set; }

        public Candy(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }

        public Candy(ICandy that)
        {
            Name = that.Name;
            Price = that.Price;
            Qty = that.Qty;
        }

        public override string ToString()
        {
            return $"{Name},{Price},{Qty}";
        }

        public override bool Equals(object obj)
        {
            return Name == (obj as Candy).Name
                && Price == (obj as Candy).Price
                && Qty == (obj as Candy).Qty;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
