using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] platesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> guests = new Queue<int>();
            for (int i = 0; i < guestsInfo.Length; i++)
            {
                guests.Enqueue(guestsInfo[i]);
            }
            Stack<int> plates = new Stack<int>();
            for (int i = 0; i < platesInfo.Length; i++)
            {
                plates.Push(platesInfo[i]);
            }

            int wastedFood = 0;

            while (guests.Any() && plates.Any())
            {
                int currentGuest = guests.Dequeue();
                while (currentGuest > 0)
                {
                    int currentPlate = plates.Pop();
                    currentGuest -= currentPlate;

                    if (currentGuest < 0)
                    {
                        wastedFood += Math.Abs(currentGuest);
                    }
                }
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
