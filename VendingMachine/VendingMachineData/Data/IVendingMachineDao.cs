using System;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineData.Data
{
    public interface IVendingMachineDao
    {
        public VendingMachine VendingMachine { get; }

        public string FilePath { get; set; }

        public void OverwriteFile();

        public void RemoveCandy(string candyName);

        public VendingMachine GetVendingMachine();
    }
}
