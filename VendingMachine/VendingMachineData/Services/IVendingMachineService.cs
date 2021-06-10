using System;
using System.Collections.Generic;
using VendingMachineData.Data;
using VendingMachineData.Models;

namespace VendingMachineData.Services
{
    public interface IVendingMachineService
    {
        public List<Candy> GetCandies();
        public Change PurchaseCandy(Candy candy, decimal funds);
        public decimal GetFunds();
        public void DisplayCandies();
    }
}
