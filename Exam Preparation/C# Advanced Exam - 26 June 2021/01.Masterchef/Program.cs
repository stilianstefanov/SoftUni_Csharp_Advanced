using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] freshnessInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>();
            for (int i = 0; i < ingredientsInfo.Length; i++)
            {
                ingredients.Enqueue(ingredientsInfo[i]);
            }

            Stack<int> freshness = new Stack<int>();
            for (int i = 0; i < freshnessInfo.Length; i++)
            {
                freshness.Push(freshnessInfo[i]);
            }

            Dictionary<string, int> dishesInfo = new Dictionary<string, int>();
            dishesInfo.Add("Dipping sauce", 150);
            dishesInfo.Add("Green salad", 250);
            dishesInfo.Add("Chocolate cake", 300);
            dishesInfo.Add("Lobster", 400);

            Dictionary<string, int> dishesMade = new Dictionary<string, int>();

            while (ingredients.Any() && freshness.Any())
            {
                while (ingredients.Any() && ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                
                if (!ingredients.Any() || !freshness.Any())
                {
                    break;
                }

                int currentIngredient = ingredients.Peek();
                int currentFreshness = freshness.Pop();
                int result = currentIngredient * currentFreshness;

                if (dishesInfo.ContainsValue(result))
                {
                    string dishMade = dishesInfo.First(d => d.Value == result).Key;
                    if (!dishesMade.Any(d => d.Key == dishMade))
                    {
                        dishesMade.Add(dishMade, 0);
                    }
                    dishesMade[dishMade]++;
                    ingredients.Dequeue();
                }
                else
                {
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (dishesMade.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            if (dishesMade.Count > 0)
            {
                foreach (var item in dishesMade.OrderBy(d => d.Key))
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }            
        }
    }
}
