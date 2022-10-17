using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] scarfsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hats = new Stack<int>(hatsInfo);
            Queue<int> scarfs = new Queue<int>(scarfsInfo);

            List<int> finalSets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {                
                int currentScarf = scarfs.Peek();

                while (hats.Any() && hats.Peek() < currentScarf)
                {
                    hats.Pop();
                }
                if (!hats.Any())
                {
                    break;
                }
                int currentHat = hats.Peek();

                if (currentHat > currentScarf)
                {
                    finalSets.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }               
            }
            Console.WriteLine($"The most expensive set is: {finalSets.Max()}");
            Console.WriteLine(string.Join(" ", finalSets));
        }
    }
}
