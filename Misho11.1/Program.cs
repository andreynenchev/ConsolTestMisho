
using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Misho11._1
{
    class Program
    {
        public static bool[] PrimeListBool { get; set; }
        public static List<int> PrimeList { get; set; }
        static void Main(string[] args)
        {
            // Task1();


            //SumofOddSquares();

            //Multiplesof3or5();
            CreatePrimeList();

            LargestPrimeFactor();
        }

        private static void CreatePrimeList()
        {
            Console.WriteLine($"\t(start)");
            var sw = new Stopwatch();
            sw.Start();
            int length = 10000000;
            PrimeListBool = new bool[length];
            PrimeList = new List<int>(10000000);
            for (int i = 1; i < length; i++)
            {
                PrimeListBool[i] = true;
            }
            Console.WriteLine($"\t({sw.Elapsed.TotalMilliseconds} ms)");
            for (int i = 2; i < length; i++)
            {
                if (PrimeListBool[i])
                {   
                    PrimeList.Add(i);
                    for (int j = i + i; j < length; j += i)
                    {
                        PrimeListBool[j] = false;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"\t({sw.Elapsed.TotalMilliseconds} ms)");

            for (int i = PrimeList.Count - 100; i < PrimeList.Count; i++)
            {
                Console.WriteLine($"{i} : {PrimeList[i]}");
            }
            Console.ReadLine();
        }


        //Largest Prime Factor
        private static void LargestPrimeFactor()
        {
            
            long number = 600851475143;
            int maxprime = 1;
            int i = 1;
            while (i<1000000)
            {
                i++;
                if (PrimeListBool[i] && number % i==0)
                {
                    Console.WriteLine($"{number} / {i} = {number / i}");
                    maxprime = i;
                }
            }
            Console.WriteLine($"{maxprime}");
            Console.ReadLine();
        }

        private static void Multiplesof3or5()
        {
            int SumofMultiples = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    SumofMultiples += i;
                }
            }
            Console.WriteLine($"{SumofMultiples}");
            Console.ReadLine();
        }

        private static void SumofOddSquares()
        {
            //620645833307500
            //620645833307500
            long sumOfOddSquares = 0;
            int numberOfSquares = 0;
            long n = 0;
            while (numberOfSquares < 155000)
            {
                n++;
                long square = n * n;
                numberOfSquares++;
                if (square % 2 != 0)
                {
                    sumOfOddSquares += square;
                    //Console.WriteLine($"{numberOfSquares} {n} {sumOfOddSquares}");
                }
            }
            Console.WriteLine($"{numberOfSquares} : {sumOfOddSquares}");
            Console.ReadLine();
        }



        private static void Task1()
        {
            string line = Console.ReadLine();
            while (line != null && line.Length > 0)
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
