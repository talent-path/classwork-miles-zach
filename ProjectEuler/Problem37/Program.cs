using System;
using System.Collections.Generic;
using Utils;

namespace Problem37
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int count = 0;
            for(int i = 23; count < 11; i+=2)
            {
                if(Util.IsPrime(i) && IsTruncatable(i))
                {
                    sum += i;
                    count++;
                }
            }

            Console.WriteLine(sum);
            
        }

        static bool LeftToRight(int x)
        {
            string s = x.ToString();
            while(s.Length > 1)
            {
                s = s.Substring(1);
                x = int.Parse(s);
                if (!Util.IsPrime(x))
                    return false;
            }
            return true;
        }
        

        static bool RightToLeft(int x)
        {
            string s = x.ToString();
            while (s.Length > 1)
            {
                s = s.Remove(s.Length - 1);
                x = int.Parse(s);
                if (!Util.IsPrime(x))
                    return false;
            }
            return true;
        }

        static bool IsTruncatable(int n)
        {
            int num1 = n / 10;
            int num2 = int.Parse(n.ToString()[1..]);
            while (num1 > 0 && num2 > 0)
            {
                if(!Util.IsPrime(num1) || !Util.IsPrime(num2))
                {
                    return false;
                }
                num1 /= 10;
                if (num2 > 10)
                    num2 = int.Parse(num2.ToString()[1..]);
                else num2 = -1;
            }
            return true;
        }


    }
}
