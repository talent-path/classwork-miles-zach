using System;
namespace Nasdaq
{
    public class DailyQuote
    {

        public DateTime Date { get; }
        public decimal Close { get; }
        public ulong Volume { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public DailyQuote(
            DateTime Date,
            decimal Close,
            ulong Volume,
            decimal Open,
            decimal High,
            decimal Low)
        {
            this.Date = Date;
            this.Close = Close;
            this.Volume = Volume;
            this.Open = Open;
            this.High = High;
            this.Low = Low;
        }

        public DailyQuote(string line)
        {
            string[] values = line.Split(',');
            for(int i = 0; i < values.Length; i++)
            {
                switch(i)
                {
                    case 0:
                        Date = DateTime.Parse(values[i]);
                        break;
                    case 1:
                        Close = decimal.Parse(values[i].Substring(1));
                        break;
                    case 2:
                        Volume = ulong.Parse(values[i]);
                        break;
                    case 3:
                        Open = decimal.Parse(values[i].Substring(1));
                        break;
                    case 4:
                        High = decimal.Parse(values[i].Substring(1));
                        break;
                    case 5:
                        Low = decimal.Parse(values[i].Substring(1));
                        break;
                    default:
                        Console.WriteLine("The sky is falling!");
                        break;
                }
            }
        }
    }
}
