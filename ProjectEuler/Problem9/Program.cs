using System;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            int product = int.MinValue;
            bool done = false;
            for(int a = 1; a < 1000 && !done; a++)
            {
                for(int b = 1; b < 1000; b++)
                {
                    int c = 1000 - a - b;
                    if(a * a + b * b == c * c
                        && a + b + c == 1000)
                    {
                        product = a * b * c;
                        done = true;
                        break;
                    }
                }
            }
            Console.WriteLine(product);
        }
    }
}
