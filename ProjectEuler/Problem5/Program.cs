using System;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            // divisible by 20 also divisible by 10, 5
            // divisible by 18 also divisible by 9, 6, 3
            // divisible by 16 also divisible 8, 4, 2
            // divisible by 14 also divisible by 7
            // go to 11

            long smallest = int.MaxValue;

            for(long i = 1; i < long.MaxValue; i++)
            {
                bool flag = true;
                for(int j = 20; j > 10; j--)
                {
                    if(i % j != 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    smallest = i;
                    break;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
