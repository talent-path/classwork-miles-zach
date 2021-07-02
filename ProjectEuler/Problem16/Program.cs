using System;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 1;
            for(int i = 0; i < 1000; i++)
            {
                num *= 2;
            }

            BigInteger sum = 0;

            while(num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
