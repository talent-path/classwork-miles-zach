using System;
using Utils;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = (int) (Math.Pow(2, 4) * Math.Pow(3, 4) * Math.Pow(5, 4) * 7 * 11);
            while(!Util.IsTriangleNumber(num))
            {
                num += 1;
            }

            int seriesLastTerm = Util.LastTerm(num);

            while(Util.CountDivisors(num) <= 500)
            {
                num += (seriesLastTerm++ + 1);
            }

            Console.WriteLine(num);
        }
        
    }
}
