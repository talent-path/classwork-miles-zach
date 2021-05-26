using System;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            if (num % 2 == 0) return false;
            for (var i = 3; i <= Sqrt(num); i+=2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger Sqrt(BigInteger num)
        {
            BigInteger sqrt = BigInteger.MinusOne;
            for(int i = 1; i < num; i++)
            {
                if(i * i > num)
                {
                    sqrt = i - 1;
                    break;
                }
            }
            return sqrt;
        }

        public static bool IsPalindrome(int num)
        {
            string str = num.ToString();
            int length = str.Length;
            string firstHalf = str.Substring(0, length / 2);
            string otherHalf = str.Substring(length / 2);

            char[] arr = otherHalf.ToCharArray();
            Array.Reverse(arr);

            otherHalf = String.Concat(arr);

            return firstHalf == otherHalf;
        }
    }
}
