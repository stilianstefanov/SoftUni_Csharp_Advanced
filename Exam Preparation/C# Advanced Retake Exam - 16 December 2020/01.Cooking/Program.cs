using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> foodInfo = new Dictionary<string, int>();
            foodInfo.Add("Bread", 25);
            foodInfo.Add("Cake", 50);
            foodInfo.Add("Pastry", 75);
            foodInfo.Add("Fruit Pie", 100);

            Dictionary<string, int> foodMade = new Dictionary<string, int>();
            foodMade.Add("Bread", 0);
            foodMade.Add("Cake", 0);
            foodMade.Add("Pastry", 0);
            foodMade.Add("Fruit Pie", 0);

            while (liquids.Any() && ingredients.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();
                int result = currentIngredient + currentLiquid;

                if (foodInfo.ContainsValue(result))
                {
                    string curFoodmade = foodInfo.First(f => f.Value == result).Key;

                    foodMade[curFoodmade]++;
                }
                else
                {
                    ingredients.Push(currentIngredient + 3);
                }
            }

            PrintResult(liquids, ingredients, foodMade);
        }

        private static void PrintResult(Queue<int> liquids, Stack<int> ingredients, Dictionary<string, int> foodMade)
        {
            if (!foodMade.Any(f => f.Value == 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (!ingredients.Any())
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var food in foodMade.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
