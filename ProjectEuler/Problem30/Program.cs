using System;
using System.Collections.Generic;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for(int i = 10; i < 999999; i++)
            {
                int s = 0;
                int c = i;
                while(c != 0)
                {
                    int d = c % 10;
                    c /= 10;
                    s += d * d * d * d * d;
                }
                if (s == i) sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
