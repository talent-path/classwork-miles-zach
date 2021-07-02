using System;
using System.Collections.Generic;

namespace Problem17
{
    class Program
    {
        private static Dictionary<int, string> _dictionary = new Dictionary<int, string>()
        {
            [0] = "",
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
            [11] = "eleven",
            [12] = "twelve",
            [13] = "thirteen",
            [14] = "fourteen",
            [15] = "fifteen",
            [16] = "sixteen",
            [17] = "seventeen",
            [18] = "eighteen",
            [19] = "nineteen",
            [20] = "twenty",
            [30] = "thirty",
            [40] = "forty",
            [50] = "fifty",
            [60] = "sixty",
            [70] = "seventy",
            [80] = "eigthy",
            [90] = "ninety",
            [100] = "hundred",
            [1000] = "thousand"
        };
        static void Main(string[] args)
        {
            int letterSum = 0;
            for (int i = 1; i <= 1000; i++)
            {

                if (i >= 1 && i <= 20)
                    letterSum += OneThroughTwenty(i);
                else if (i >= 21 && i <= 99)
                    letterSum += TwentyOneThroughNinetyNine(i);
                else if (i >= 100 && i <= 999)
                    letterSum += OneHundredThrough999(i);
                else
                    letterSum += _dictionary[1000].Length + 3;

            }
            Console.WriteLine("Count: " + letterSum);
        }
        public static int OneThroughTwenty(int num)
        {
            return _dictionary[num].Length;
        }
        public static int TwentyOneThroughNinetyNine(int num)
        {
            int temp = num % 10;
            return _dictionary[temp].Length + _dictionary[num - temp].Length;
        }
        public static int OneHundredThrough999(int num)
        {
            int tempHundreds = num / 100;
            int tempCount = _dictionary[tempHundreds].Length + _dictionary[100].Length;
            if (num % 100 != 0)
            {
                // "and"
                tempCount += 3;
                num %= 100;
                if (num >= 21)
                {
                    tempCount += TwentyOneThroughNinetyNine(num);
                }
                else
                    tempCount += OneThroughTwenty(num);
            }
            return tempCount;
        }
    }
}

