using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeQtys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] milkQtys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> coffees = new Queue<int>();
            for (int i = 0; i < coffeeQtys.Length; i++)
            {
                coffees.Enqueue(coffeeQtys[i]);
            }
            Stack<int> milks = new Stack<int>();
            for (int i = 0; i < milkQtys.Length; i++)
            {
                milks.Push(milkQtys[i]);
            }

            Dictionary<int, string> drinksReq = new Dictionary<int, string>();
            drinksReq.Add(50 ,"Cortado");
            drinksReq.Add(75, "Espresso");
            drinksReq.Add(100, "Capuccino");
            drinksReq.Add(150, "Americano");
            drinksReq.Add(200, "Latte");

            Dictionary<string, int> drinksMade = new Dictionary<string, int>();

            while (coffees.Any() && milks.Any())
            {
                int curCoffeeQty = coffees.Peek();
                int currMilkQty = milks.Peek();

                int sum = curCoffeeQty + currMilkQty;

                if (drinksReq.ContainsKey(sum))
                {
                    string curDrinkMade = drinksReq[sum];
                    if (!drinksMade.ContainsKey(curDrinkMade))
                    {
                        drinksMade.Add(curDrinkMade, 0);
                    }
                    drinksMade[curDrinkMade] += 1;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else
                {
                    coffees.Dequeue();                  
                    milks.Push(milks.Pop() - 5);
                }
            }            

            if (coffees.Count == 0 && milks.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffees.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffees)}");
            }
            if (milks.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milks)}");
            }

            foreach (var drink in drinksMade.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
