using System;
using System.Collections.Generic;
using VendingMachineData.Enums;

namespace VendingMachineData.Models
{
    public class Change : IChange
    {
        public Dictionary<Money, int> Coins { get; } = new Dictionary<Money, int>()
        {
            { Money.Penny, 0 },
            { Money.Nickel, 0 },
            { Money.Dime, 0 },
            { Money.Quarter, 0 },
            { Money.Dollar, 0 }
        };

        public Change(decimal change)
        {
            if(change >= 1)
            {
                Coins[Money.Dollar] = (int) change / 1;
                change -= change / 1;
            }

            if (change >= 0.25M)
            {
                Coins[Money.Quarter] = (int) Math.Round(change / 0.25M);
                change -= change / 0.25M;
            }

            if(change >= 0.10M)
            {
                Coins[Money.Dime] = (int) Math.Round(change / 0.10M);
                change -= change / 0.10M;
            }

            if (change >= 0.05M)
            {
                Coins[Money.Nickel] = (int) Math.Round(change / 0.05M);
                change -= change / 0.05M;
            }

            if (change >= 0.01M)
            {
                Coins[Money.Penny] = (int) Math.Round(change / 0.01M);
                change -= change / 0.01M;
            }
        }
    }
}
