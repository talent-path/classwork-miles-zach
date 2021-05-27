using System;
namespace Nasdaq
{
    public class Report
    {
        public int Year { get; }
        public decimal Open { get; }
        public decimal Close { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public Report(int Year, decimal Open, decimal Close, decimal High, decimal Low)
        {
            this.Year = Year;
            this.Open = Open;
            this.Close = Close;
            this.High = High;
            this.Low = Low;
        }

        public override string ToString()
        {
            return Year +
                ": {\n\topen: " + Open
                + ",\n\tclose: " + Close
                + ",\n\thigh: " + High
                + ",\n\tlow: " + Low
                + "\n}";
        }
    }
}
