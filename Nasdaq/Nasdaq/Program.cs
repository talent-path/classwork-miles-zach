using System;
using System.Collections.Generic;
using System.IO;

namespace Nasdaq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * group data by year
             * get standard deviation for:
             * open
             * high
             * low
             * close
             * output should be a dictionary that maps from year to a list of
             * answers for that year
             * you could also make a class to hold the report for the year
             * 
            */
            Dictionary<int, List<DailyQuote>> yearlyQuotes = new Dictionary<int, List<DailyQuote>>();
            using (StreamReader reader = new StreamReader("../../../../GOOG.csv"))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    DailyQuote quote = new DailyQuote(line);
                    int year = quote.Date.Year;
                    if (yearlyQuotes.ContainsKey(year))
                    {
                        List<DailyQuote> quotes = null;
                        yearlyQuotes.TryGetValue(year, out quotes);
                        quotes.Add(quote);
                    }
                    else
                    {
                        yearlyQuotes.Add(year, new List<DailyQuote>(new DailyQuote[] { quote }));
                    }
                }
            }

            List<Report> reports = new List<Report>();
            foreach (KeyValuePair<int, List<DailyQuote>> entry in yearlyQuotes)
            {
                Report report = GenerateReport(entry);
                reports.Add(report);
                Console.WriteLine(report);
            }
        }

        public static Report GenerateReport(KeyValuePair<int, List<DailyQuote>> entry)
        {
            List<decimal> open = new List<Decimal>();
            List<decimal> close = new List<Decimal>();
            List<decimal> high = new List<Decimal>();
            List<decimal> low = new List<Decimal>();
            foreach (DailyQuote quote in entry.Value)
            {
                open.Add(quote.Open);
                close.Add(quote.Close);
                high.Add(quote.High);
                low.Add(quote.Low);
            }

            return new Report(
                entry.Key,
                StandardDeviation(open),
                StandardDeviation(close),
                StandardDeviation(high),
                StandardDeviation(low)
            );
        }

        /*
                1.Work out the Mean(the simple average of the numbers)
                2.Then for each number: subtract the Mean and square the result
                3.Then work out the mean of those squared differences.
                4.Take the square root of that and we are done!
        */

        public static decimal StandardDeviation(List<decimal> nums)
        {
            decimal mean = Mean(nums);
            List<decimal> subtractMeanSquareResult = SubtractMeanSquareResult(nums, mean);
            decimal meanOfSquaredDifferences = Mean(subtractMeanSquareResult);
            return Sqrt(meanOfSquaredDifferences);
        }

        public static decimal Mean(List<decimal> nums)
        {
            decimal mean = 0;
            foreach (decimal num in nums)
            {
                mean += num;
            }
            return mean / nums.Count;
        }

        public static List<decimal> SubtractMeanSquareResult(List<decimal> nums, decimal mean)
        {
            List<decimal> output = new List<decimal>();
            foreach (decimal num in nums)
            {
                decimal toSquare = num - mean;
                output.Add(toSquare * toSquare);
            }
            return output;
        }

        public static decimal Sqrt(decimal num)
        {
            return (decimal)Math.Sqrt((double)num);
        }
    }
}
