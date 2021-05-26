using System;
using Utils;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 6;
            for(long i = 17; i < long.MaxValue; i++)
            {
                if(Util.IsPrime(i))
                {
                    count++;
                }

                if(count == 10001)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
