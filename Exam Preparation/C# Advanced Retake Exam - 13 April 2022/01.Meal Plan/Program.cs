using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray());
            Dictionary<string, int> caloriesPerMeal = new Dictionary<string, int>();
            caloriesPerMeal.Add("salad", 350);
            caloriesPerMeal.Add("soup", 490);
            caloriesPerMeal.Add("pasta", 680);
            caloriesPerMeal.Add("steak", 790);

            int mealsEaten = 0;

            while (meals.Any() && calories.Any() && calories.Peek() > 0)
            {
                int dailyCalories = calories.Pop();
                string meal = meals.Dequeue();
                mealsEaten++;
                int currentMealCalories = caloriesPerMeal[meal];
                dailyCalories -= currentMealCalories;

                while (dailyCalories <= 0)
                {
                    if (!calories.Any()) break;
                    dailyCalories += calories.Pop();
                }
                calories.Push(dailyCalories);
            }
            PrintResult(meals, calories, mealsEaten);
        }
        private static void PrintResult(Queue<string> meals, Stack<int> calories, int mealsEaten)
        {
            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}