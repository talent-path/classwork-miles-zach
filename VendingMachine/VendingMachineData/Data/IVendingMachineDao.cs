using System;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineData.Data
{
    public interface IVendingMachineDao
    {
        public void RemoveCandy(string candyName);

        public List<Candy> GetCandies();
    }
}
