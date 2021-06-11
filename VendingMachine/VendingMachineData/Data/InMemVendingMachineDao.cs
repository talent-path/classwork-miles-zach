using System.Collections.Generic;
using VendingMachineData.Models;
using System.Linq;

namespace VendingMachineData.Data
{
    public class InMemVendingMachineDao : IVendingMachineDao
    {

        private List<Candy> _candies = new List<Candy>();

        public InMemVendingMachineDao()
        {
            _candies.Add(new Candy("Jolly Rancher", 1.00M, 13));
            _candies.Add(new Candy("Almond Joy", 1.50M, 21));
            _candies.Add(new Candy("Snickers", 2.50M, 6));
            _candies.Add(new Candy("Three Musketeers", 3.00M, 9));
            _candies.Add(new Candy("Starburst", 0.50M, 10));
            _candies.Add(new Candy("Reese's Cup", 1.25M, 4));
            _candies.Add(new Candy("Babe Ruth", 1.33M, 0));
            _candies.Add(new Candy("Tootsie Roll", 0.27M, -1));
        }

        public List<Candy> GetCandies()
        {
            return _candies.Select(c => new Candy(c)).ToList();
        }

        public void RemoveCandy(string candyName)
        {
            _candies = GetCandies()
                .Select(c => c.Name == candyName ? new Candy(c.Name, c.Price, c.Qty - 1) : c)
                .ToList();
        }
    }
}
