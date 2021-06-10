using System;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineData
{
    public interface IVendingMachine
    {
        public List<Candy> Candies { get; set; }
    }
}
