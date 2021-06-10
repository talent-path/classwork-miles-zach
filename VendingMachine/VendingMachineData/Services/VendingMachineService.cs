using System;
using System.Collections.Generic;
using VendingMachineData.Data;
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
            if(funds > candy.Price && candy.Qty > 0)
            {
                _vendingMachineDao.RemoveCandy(candy);
                return new Change(funds - candy.Price);
            }
            else 
            {
                return new Change(funds);
            }
        }

        public void DisplayCandies()
        {
            Console.WriteLine("-----Vending Machine Items-----");
            foreach (Candy candy in GetCandies())
            {
                Console.WriteLine($"Enter {GetCandies().IndexOf(candy)} for {candy.Name} ${candy.Price}" +
                    $" with {candy.Qty} in stock");
            }
            Console.WriteLine("-------------------------------");
        }


        public decimal GetFunds()
        {
            decimal funds = decimal.MinValue;
            bool success = false;
            while (funds <= 0 && !success)
            {
                Console.Write("Enter the amount of money you want to spend: ");
                success = decimal.TryParse(Console.ReadLine(), out funds);
            }
            return funds;
        }
    }
}
