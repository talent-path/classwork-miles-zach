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
            return _vendingMachineDao.GetCandies();
        }

        public Change PurchaseCandy(Candy candy, decimal funds)
        {
            if(funds < candy.Price)
            {
                throw new InsufficientFundsException($"Unable to purchase {candy.Name} with ${funds}");
            }

            if(candy.Qty <= 0)
            {
                throw new OutOfStockException($"{candy.Name} is out of stock.");
            }

            _vendingMachineDao.RemoveCandy(candy.Name);
            return new Change(funds - candy.Price);
        }
    }
}
