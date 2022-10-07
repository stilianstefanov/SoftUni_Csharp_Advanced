using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] carbonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steel = new Queue<int>();
            for (int i = 0; i < steelInfo.Length; i++)
            {
                steel.Enqueue(steelInfo[i]);
            }
            Stack<int> carbon = new Stack<int>();
            for (int i = 0; i < carbonInfo.Length; i++)
            {
                carbon.Push(carbonInfo[i]);
            }

            Dictionary<string, int> swordsInfo = new Dictionary<string, int>();
            swordsInfo.Add("Gladius", 70);
            swordsInfo.Add("Shamshir", 80);
            swordsInfo.Add("Katana", 90);
            swordsInfo.Add("Sabre", 110);
            swordsInfo.Add("Broadsword", 150);

            Dictionary<string, int> swordsMade = new Dictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int curSteel = steel.Dequeue();
                int curCarbon = carbon.Peek();

                int sum = curSteel + curCarbon;

                if (swordsInfo.ContainsValue(sum))
                {
                    string sword = swordsInfo.First(s => s.Value == sum).Key;
                    if (!swordsMade.Any(s => s.Key == sword))
                    {
                        swordsMade.Add(sword, 0);
                    }
                    swordsMade[sword]++;
                    carbon.Pop();
                }
                else
                {
                    carbon.Push(carbon.Pop() + 5);
                }
            }

            if (swordsMade.Count > 0)
            {
                Console.WriteLine($"You have forged {swordsMade.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (!steel.Any())
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (!carbon.Any())
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            if (swordsMade.Count > 0)
            {
                foreach (var sword in swordsMade.OrderBy(s => s.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
