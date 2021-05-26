using System;
using Utils;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;

         

            for(int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    if (Util.IsPalindrome(j * i) && i * j > max)
                    {
                        max = i * j;
                        Console.WriteLine(max);
                        break;
                    }
                }
            }
        }
    }
}
