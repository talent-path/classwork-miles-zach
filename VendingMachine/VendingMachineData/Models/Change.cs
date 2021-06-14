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
                change -= Coins[Money.Dollar];
            }

            if (change >= 0.25M)
            {
                Coins[Money.Quarter] = (int) Math.Floor(change / 0.25M);
                change -= Coins[Money.Quarter] * 0.25M;
            }

            if(change >= 0.10M)
            {
                Coins[Money.Dime] = (int) Math.Floor(change / 0.10M);
                change -= Coins[Money.Dime] * 0.10M;
            }

            if (change >= 0.05M)
            {
                Coins[Money.Nickel] = (int)Math.Floor(change / 0.05M);
                change -= Coins[Money.Nickel] *  0.05M;
            }

            if (change >= 0.01M)
            {
                Coins[Money.Penny] = (int) Math.Floor(change / 0.01M);
            }
        }

        public Change(int dollars, int quarters, int dimes, int nickels, int pennies)
        {
            Coins[Money.Dollar] = dollars;
            Coins[Money.Quarter] = quarters;
            Coins[Money.Dime] = dimes;
            Coins[Money.Nickel] = nickels;
            Coins[Money.Penny] = pennies;
        }

        public decimal ToDecimal()
        {
            decimal val = 0.00M;
            foreach(var entry in Coins)
            {
                val += ((int) entry.Key * 0.01M) * entry.Value;
            }
            return val;
        }

        public override string ToString()
        {
            string val = "Change returned";
            foreach(var entry in Coins)
            {
                val += $"\n{entry.Value} {entry.Key}(s)";
            }
            return val;
        }
    }
}
