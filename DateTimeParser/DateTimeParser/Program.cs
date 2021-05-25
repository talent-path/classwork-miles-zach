using System;

namespace DateTimeParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user for date in specified format
            // Find the next friday and print out how many days are between
            // entered date and the friday.
            while (true)
            {


                Console.Write("Enter a date in the format (MM-dd-yyyy): ");

                string input = Console.ReadLine();

                DateTime date = DateTime.ParseExact(input, "MM-dd-yyyy", null);

                DayOfWeek day = date.DayOfWeek;

                switch (day)
                {
                    case DayOfWeek.Monday:
                        date = date.AddDays(4);
                        break;
                    case DayOfWeek.Tuesday:
                        date = date.AddDays(3);
                        break;
                    case DayOfWeek.Wednesday:
                        date = date.AddDays(2);
                        break;
                    case DayOfWeek.Thursday:
                        date = date.AddDays(1);
                        break;
                    case DayOfWeek.Friday:
                        date = date.AddDays(7);
                        break;
                    case DayOfWeek.Saturday:
                        date = date.AddDays(6);
                        break;
                    case DayOfWeek.Sunday:
                        date = date.AddDays(5);
                        break;
                    default:
                        Console.WriteLine("The sky is falling!");
                        break;
                }

                Console.WriteLine(date);
            }
        }
    }
}
