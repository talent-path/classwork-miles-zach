using System;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = new DateTime(1901, 1, 1);
            DateTime end = new DateTime(2000, 12, 31);
            int sundays = 0;
            while((start = start.AddMonths(1)) < end)
            {
                if (start.DayOfWeek == DayOfWeek.Sunday) sundays++;
            }
            Console.WriteLine(sundays);
        }
    }
}
