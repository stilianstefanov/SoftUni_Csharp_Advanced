using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int caffeineTotal = 0;

            while (caffeine.Any() && energyDrinks.Any())
            {
                int currentCaffeine = caffeine.Pop();
                int currentDrink = energyDrinks.Dequeue();

                int result = currentCaffeine * currentDrink;

                if (caffeineTotal + result <= 300)
                {
                    caffeineTotal += result;
                }
                else
                {
                    energyDrinks.Enqueue(currentDrink);
                    if (caffeineTotal - 30 < 0)
                    {
                        caffeineTotal = 0;
                    }
                    else
                    {
                        caffeineTotal -= 30;
                    }
                }
            }

            if (!energyDrinks.Any())
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            else
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            Console.WriteLine($"Stamat is going to sleep with {caffeineTotal} mg caffeine.");
        }
    }
}
