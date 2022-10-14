using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondBoxInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> firstBox = new Queue<int>();
            for (int i = 0; i < firstBoxInfo.Length; i++)
            {
                firstBox.Enqueue(firstBoxInfo[i]);
            }
            Stack<int> secondBox = new Stack<int>();
            for (int i = 0; i < secondBoxInfo.Length; i++)
            {
                secondBox.Push(secondBoxInfo[i]);
            }

            int sum = 0;
            while (firstBox.Any() && secondBox.Any())
            {
                int firstBoxValue = firstBox.Peek();
                int secondBoxValue = secondBox.Peek();
                int result = firstBoxValue + secondBoxValue;

                if (result % 2 == 0)
                {
                    sum += result;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
