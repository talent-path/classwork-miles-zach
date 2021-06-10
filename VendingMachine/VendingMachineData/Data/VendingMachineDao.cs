using System;
using System.Collections.Generic;
using System.IO;
using VendingMachineData.Models;
using System.Linq;

namespace VendingMachineData.Data
{
    public class VendingMachineDao : IVendingMachineDao
    {
        public VendingMachine VendingMachine { get; }

        public string FilePath { get; set; }

        public VendingMachineDao(string pathToFile)
        {
            FilePath = pathToFile;
            List<Candy> candies = new List<Candy>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while((line = reader.ReadLine()) != null) {
                    string[] fields = line.Split(",");
                    Candy candy = new Candy(fields[0], decimal.Parse(fields[1]), int.Parse(fields[2]));
                    candies.Add(candy);
                }
            }
            VendingMachine = new VendingMachine(candies);
        }

        public VendingMachineDao() : this("../../../../VendingMachine/Seed.txt")
        {
            
        }

        public void OverwriteFile()
        {
            string text = "";
            foreach(Candy candy in VendingMachine.Candies)
            {
                text += candy.ToString() + "\n";
            }
            File.WriteAllText("../../../../VendingMachine/Candy.txt", text);
        }

        public void RemoveCandy(Candy candy)
        {
            VendingMachine.Candies = VendingMachine.Candies
                .Select(c => c == candy ? new Candy(c.Name, c.Price, c.Qty - 1) : c)
                .ToList();
            OverwriteFile();
        }

        public VendingMachine GetVendingMachine()
        {
            return new VendingMachine(VendingMachine);
        }
    }
}
