using System;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineData
{
    public class VendingMachine : IVendingMachine
    {
        public List<Candy> Candies { get; set; }

        public VendingMachine(List<Candy> candies)
        {
            Candies = candies;
        }

        public VendingMachine(IVendingMachine that)
        {
            Candies = new List<Candy>();
            foreach(Candy c in that.Candies)
            {
                Candies.Add(c);
            }
        }
    }
}
