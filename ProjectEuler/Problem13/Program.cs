using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Problem13
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger sum = new BigInteger();
            using (StreamReader reader = new StreamReader("Numbers.txt"))
            {
                string line = null;
                while((line = reader.ReadLine()) != null)
                {
                    sum += BigInteger.Parse(line);
                }
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine(sum); 
        }
    }
}
