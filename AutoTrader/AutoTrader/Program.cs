using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTrader
{
    class Program
    {
        static readonly HttpClient _httpClient = new HttpClient();
        static readonly Mutex _lock = new Mutex();
        static Dictionary<string, List<decimal>> _stockPrices = new Dictionary<string, List<decimal>>();
        static void Main(string[] args)
        {
            //As a user, I should be able to enter a list of stock symbols to watch(just pressing enter to indicate I'm done with a blank line).
            //As a user, I should be able to see periodic updates to prices(once a minute for each monitored stock).
            //As a user, whenever a stock crosses above the median price observed so far, I should get a message to sell that stock.
            //As a user, whenever a stock crosses below the median price observed so far, I should get a message to buy that stock.

            List<string> tickers = GetTickers();
            List<Task> tasks = new List<Task>();
            foreach (string ticker in tickers)
            {
                tasks.Add(Task.Factory.StartNew(() => GetStockPrices(ticker)).Unwrap());
            }

            Task.WaitAll(tasks.ToArray());
        }

        static List<string> GetTickers()
        {
            List<string> tickers = new List<string>();
            Console.WriteLine("Enter a stock symbol then press enter. Press enter twice when you are done.");
            while(true)
            {
                string symbol = Console.ReadLine().ToUpper();
                if (symbol == "")
                {
                    break;
                }
                tickers.Add(symbol);
            }
            return tickers;
        }

        static decimal MedianStockPrice(List<decimal> prices)
        {
            prices.Sort();
            if(prices.Count % 2 == 0)
            {
                return (prices[(prices.Count / 2) - 1] + prices[prices.Count / 2]) / 2;
            }
            else
            {
                return prices[prices.Count / 2];
            }
        }

        static async Task GetStockPrices(string ticker)
        {
            while (true)
            {
                string body = null;
                try
                {
                    HttpResponseMessage res = await _httpClient.GetAsync($"https://finnhub.io/api/v1/quote?symbol={ticker}&token=c2t4il2ad3i9opckhnr0");
                    res.EnsureSuccessStatusCode();
                    body = await res.Content.ReadAsStringAsync();
                    Match match = Regex.Match(body, @"(?<={""c"":)[^,]+");
                    decimal price = decimal.Parse(match.ToString());
                    Console.WriteLine($"{DateTime.UtcNow} {ticker}: ${price}");
                    _lock.WaitOne();
                    if (_stockPrices.ContainsKey(ticker))
                    {
                        if (_stockPrices.GetValueOrDefault(ticker).Count > 2)
                        {
                            decimal median = MedianStockPrice(_stockPrices.GetValueOrDefault(ticker));
                            if (price > median) Console.WriteLine($"Sell signal for {ticker}");
                            else if (price < median) Console.WriteLine($"Buy signal for {ticker}");
                        }
                        _stockPrices.GetValueOrDefault(ticker).Add(price);
                    }
                    else
                    {
                        _stockPrices.Add(ticker, new List<decimal> { price });
                    }
                    _lock.ReleaseMutex();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
                await Task.Delay(60000);
            }
            
        }
    }
}
