using System;
using System.Numerics;
using Utils;

namespace Problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger fact20 = Util.Factorial(20);
            Console.WriteLine(Util.Factorial(40) / (fact20 * fact20));
        }
    }
}
