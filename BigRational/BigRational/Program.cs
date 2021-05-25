using System;
using System.Numerics;

namespace BigRational
{
    class Program
    {
        static void Main(string[] args)
        {
            BigRational twoThirds = new BigRational(2, 3);
            BigRational threeFourths = new BigRational(3, 4);

            Console.WriteLine(twoThirds < threeFourths);
            Console.WriteLine(twoThirds > threeFourths);
            Console.WriteLine(threeFourths < twoThirds);
            Console.WriteLine(threeFourths > twoThirds);
        }
    }
}
