using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double[] flourInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Queue<double> water = new Queue<double>();
            for (int i = 0; i < waterInfo.Length; i++)
            {
                water.Enqueue(waterInfo[i]);
            }
            Stack<double> flour = new Stack<double>();
            for (int i = 0; i < flourInfo.Length; i++)
            {
                flour.Push(flourInfo[i]);
            }

            Dictionary<string, double> bakeryInfo = new Dictionary<string, double>();
            bakeryInfo.Add("Croissant", 50);
            bakeryInfo.Add("Muffin", 40);
            bakeryInfo.Add("Baguette", 30);
            bakeryInfo.Add("Bagel", 20);

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                double curWater = water.Dequeue();
                double curFlour = flour.Peek();

                double sum = curWater + curFlour;
                double waterPercentage = (curWater * 100) / sum;

                if (bakeryInfo.ContainsValue(waterPercentage))
                {
                    string bakeryMade = bakeryInfo.First(x => x.Value == waterPercentage).Key;
                    if (!bakedProducts.Any(x => x.Key == bakeryMade))
                    {
                        bakedProducts.Add(bakeryMade, 0);
                    }
                    bakedProducts[bakeryMade]++;
                    flour.Pop();
                }
                else
                {
                    double excessiveFlour = curFlour - curWater;

                    if (!bakedProducts.Any(x => x.Key == "Croissant"))
                    {
                        bakedProducts.Add("Croissant", 0);
                    }
                    bakedProducts["Croissant"]++;
                    flour.Pop();
                    flour.Push(excessiveFlour);
                }
            }

            foreach (var item in bakedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (!water.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (!flour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
