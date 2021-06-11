using System.Collections.Generic;
using System.IO;
using VendingMachineData.Models;
using System.Linq;

namespace VendingMachineData.Data
{
    public class FileVendingMachineDao : IVendingMachineDao
    {
        public string FilePath { get; set; }

        public FileVendingMachineDao(string pathToFile)
        {
            FilePath = pathToFile;
        }

        public FileVendingMachineDao() : this("../../../../VendingMachine/Prod.txt")
        {
            
        }

        public void OverwriteFile(List<Candy> candies)
        {
            string text = "";
            foreach(Candy candy in candies)
            {
                text += candy.ToString() + "\n";
            }
            File.WriteAllText(FilePath, text);
        }

        public void RemoveCandy(string candyName)
        {
            var candies = GetCandies()
                .Select(c => c.Name == candyName ? new Candy(c.Name, c.Price, c.Qty - 1) : c)
                .ToList();
            OverwriteFile(candies);
        }

        public List<Candy> GetCandies()
        {
            List<Candy> candies = new List<Candy>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(",");
                    Candy candy = new Candy(fields[0], decimal.Parse(fields[1]), int.Parse(fields[2]));
                    candies.Add(candy);
                }
            }
            return candies;
        }
    }
}
