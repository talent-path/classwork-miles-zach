using System;
using System.Numerics;
using Utils;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = 600851475143;

            BigInteger sqrt = Util.Sqrt(number);

            BigInteger lowFactor = int.MinValue;

            bool found = false;

            for(var i = 1; i <= sqrt; i++)
            {
                if(number % i == 0)
                {
                    BigInteger bigFactor = number / i;

                    if(Util.IsPrime(bigFactor))
                    {
                        Console.WriteLine(bigFactor);
                        found = true;
                        break;
                    }

                    if(Util.IsPrime(i))
                    {
                        lowFactor = i;
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine(lowFactor);
            }
        }
    }
}
