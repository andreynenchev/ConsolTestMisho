
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Misho11._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line!=null && line.Length > 0)
            {
                //ClaculateSimple(line);
                ClaculateBetter(line);
                line = Console.ReadLine();
            }
        }

        private static void ClaculateSimple(string line)
        {
            var sw = new Stopwatch();
            sw.Start();

            double sum, priceBeer, priceBottle;
            int SumBeer = 0;
            SumBeer = 0;
            sum = double.Parse(line.Split(' ')[0]);
            priceBeer = double.Parse(line.Split(' ')[1]);
            priceBottle = double.Parse(line.Split(' ')[2]);

            while (sum >= priceBeer)
            {
                SumBeer++;
                sum -= priceBeer;
                sum += priceBottle;
            }
            Console.Write($"{SumBeer} {sum}");
            sw.Stop();
            Console.WriteLine($"\t({sw.Elapsed.TotalMilliseconds} ms)");
        }

        private static void ClaculateBetter(string line)
        {
            var sw = new Stopwatch();
            sw.Start();

            double sum, priceBeer, priceBottle;
            int SumBeer = 0;
            SumBeer = 0;
            sum = double.Parse(line.Split(' ')[0]);
            priceBeer = double.Parse(line.Split(' ')[1]);
            priceBottle = double.Parse(line.Split(' ')[2]);

            while (sum >= priceBeer)
            {
                int beersatonce = (int)(sum / priceBeer);
                SumBeer += beersatonce;
                sum -= beersatonce * priceBeer;
                sum += beersatonce * priceBottle;
            }
            Console.WriteLine($"{SumBeer} {sum}");
            sw.Stop();
            //Console.WriteLine($"\t({sw.Elapsed.TotalMilliseconds} ms)");
        }
    }
}   
