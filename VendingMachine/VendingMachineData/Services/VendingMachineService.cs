using System;
using System.Collections.Generic;
using VendingMachineData.Data;
using VendingMachineData.Exceptions;
using VendingMachineData.Models;

namespace VendingMachineData.Services
{
    public class VendingMachineService : IVendingMachineService
    {

        private readonly IVendingMachineDao _vendingMachineDao;

        public VendingMachineService(IVendingMachineDao VendingMachineDao)
        {
            _vendingMachineDao = VendingMachineDao;
        }

        public List<Candy> GetCandies()
        {
            return _vendingMachineDao.GetVendingMachine().Candies;
            
        }

        public Change PurchaseCandy(Candy candy, decimal funds)
        {
            if(funds >= candy.Price && candy.Qty > 0)
            {
                _vendingMachineDao.RemoveCandy(candy.Name);
                return new Change(funds - candy.Price);
            }
            else 
            {
                throw new InsufficientFundsException($"Unable to purchase {candy.Name} with ${funds}");
            }
        }
    }
}
