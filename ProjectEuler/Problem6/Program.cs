using System;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            long sumOfSquares = 0;
            long squareOfSums = 0;

            for(int i = 1; i <= 100; i++)
            {
                sumOfSquares += i * i;
                squareOfSums += i;
            }

            Console.WriteLine(squareOfSums * squareOfSums - sumOfSquares);
        }
    }
}
