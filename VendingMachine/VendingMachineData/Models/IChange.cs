using System;
using System.Collections.Generic;
using VendingMachineData.Enums;

namespace VendingMachineData.Models
{
    public interface IChange
    {
        public Dictionary<Money, int> Coins { get; }
    }
}
