using System;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 1;

            for(int i = 100; i > 0; i--)
            {
                num *= i;
            }

            int sum = 0;

            while(num > 0)
            {
                sum += (int) (num % 10);
                num /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
