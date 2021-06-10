using System;
namespace VendingMachineData.Models
{
    public interface ICandy
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Qty { get; set; }
    }
}
