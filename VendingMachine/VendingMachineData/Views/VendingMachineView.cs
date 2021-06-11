using System;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineData.Views
{
    public class VendingMachineView
    {
        public VendingMachineView()
        {
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

        public int DisplayCandies(List<Candy> candies)
        {
            Console.WriteLine("-----Vending Machine Items-----");
            foreach (Candy candy in candies)
            {
                Console.WriteLine($"Enter {candies.IndexOf(candy) + 1} for {candy.Name} ${candy.Price}" +
                    $" with {candy.Qty} in stock");
            }
            Console.WriteLine("-------------------------------");

            int choice = int.MinValue;
            bool success = false;
            while (!success && (choice < 1 || choice > candies.Count))
            {
                success = int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}
