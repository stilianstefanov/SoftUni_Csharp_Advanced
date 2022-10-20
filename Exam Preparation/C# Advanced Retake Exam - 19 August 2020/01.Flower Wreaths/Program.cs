using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lillies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int flowersLeft = 0;
            int countOfWreaths = 0;
            while (lillies.Any() && roses.Any())
            {
                int currentLilly = lillies.Pop();
                int currentRose = roses.Dequeue();

                while (currentLilly + currentRose > 15)
                {
                    currentLilly -= 2;
                }

                if (currentLilly + currentRose == 15)
                {
                    countOfWreaths++;
                }
                else
                {
                    flowersLeft += (currentLilly + currentRose);
                }
            }

            int additionalWreaths = flowersLeft / 15;
            countOfWreaths += additionalWreaths;

            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }
    }
}
