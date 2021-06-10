using System;
using System.Collections.Generic;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            if (num % 2 == 0 && num != 2) return false;
            for (int i = 3; i <= Sqrt(num); i+=2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPrime(int num)
        {
            if (num % 2 == 0 && num != 2) return false;
            for (int i = 3; i <= Sqrt(num); i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPrime(List<int> primes, int num)
        {
            foreach(int prime in primes)
            {
                if(Sqrt(num) < prime)
                        break;
                if(num % prime == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountDivisors(int num)
        {
            List<int> divisors = new List<int>();
            int limit = Sqrt(num);
            for(int i = 1; i <= limit; i++)
            {
                if (num % i == 0)
                {
                    divisors.Add(i);
                    if (i != num / i) {
                        divisors.Add(num / i);
                    }
                }
            }
            return divisors.Count;
        }

        public static bool IsTriangleNumber(int num)
        {
            int a = Sqrt(2 * num);
            return 0.5 * a * (a + 1) == num;
        }

        public static int LastTerm(int n)
        {
            if (IsTriangleNumber(n))
            {
                return Sqrt(2 * n);
            }
            else return 0;
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

        public static int Sqrt(int num)
        {
            int sqrt = int.MaxValue;
            for (int i = 1; i < num; i++)
            {
                if (i * i > num)
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
