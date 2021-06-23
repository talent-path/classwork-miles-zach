using System;

namespace Problem33
{
    class Program
    {
        static void Main(string[] args)
        {
            //Digit cancelling fractions
            int num = 1;
            int den = 1;
            for (int n = 10; n < 100; n++)
            {
                for (int d = n + 1; d < 100; d++)
                {
                    int lNum = n % 10;
                    int rNum = n / 10;
                    int lDen = n % 10;
                    int rDen = n / 10;
                    int a = 0, b = 0;
                    if (rNum == rDen)
                    {
                        a = lNum;
                        b = lDen;
                    }

                    if(lNum == lDen)
                    {
                        a = rNum;
                        b = rDen;
                    }

                    if(lNum == rDen)
                    {
                        a = rNum;
                        b = lDen;
                    }

                    if(rNum == lDen)
                    {
                        a = lNum;
                        b = rDen;
                    }

                    if(a !=0 && b != 0 && CrossMultiply(a, b, n, d))
                    {
                        num *= n;
                        den *= d;
                    }

                    
                }
            }

            int gcd = GCD(num, den);
            Console.WriteLine(num/gcd);
        }

        static int GCD(int a, int b)
        {
            if (b == 0) return a;
            else return GCD(b, a % b);
        }

        static bool CrossMultiply(int a, int b, int c, int d)
        {
            return a * d == b * c;
        }
    }
}
