using System;
using Utils;
using System.Numerics;
using System.Collections.Generic;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 2;
            List<int> primes = new List<int>();
            for(int i = 3; i < 2000000; i+=2)
            {
                if (i % 1000 == 1) Console.WriteLine(i);
                if(Util.IsPrime(primes, i))
                {
                    primes.Add(i);
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
