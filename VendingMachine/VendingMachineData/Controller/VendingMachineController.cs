using System;
using System.Collections.Generic;
using VendingMachineData.Models;
using VendingMachineData.Services;

namespace VendingMachineData.Controller
{
    public class VendingMachineController
    {

        private IVendingMachineService _service;

        public VendingMachineController(IVendingMachineService service)
        {
            _service = service;
        }

        public void Run()
        {
            decimal funds = GetFunds();
            while (funds > 0.00M)
            {
                int choice = DisplayCandies() - 1;
                Console.WriteLine(_service.GetCandies()[choice].Name + " dispensed.");
                Change change = _service.PurchaseCandy(_service.GetCandies()[choice], funds);
                Console.WriteLine(change.ToString()); 
                funds = change.ToDecimal();
            }
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

        public int DisplayCandies()
        {
            List<Candy> candies = _service.GetCandies();
            Console.WriteLine("-----Vending Machine Items-----");
            foreach (Candy candy in candies)
            {
                Console.WriteLine($"Enter {candies.IndexOf(candy) + 1} for {candy.Name} ${candy.Price}" +
                    $" with {candy.Qty} in stock");
            }
            Console.WriteLine("-------------------------------");

            int choice = int.MinValue;
            bool success = false;
            while(!success && (choice < 1 || choice > candies.Count)) {
                success = int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}
