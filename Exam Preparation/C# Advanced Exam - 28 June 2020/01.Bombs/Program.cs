using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> bombsInfo = new Dictionary<string, int>();
            bombsInfo.Add("Datura Bombs", 40);
            bombsInfo.Add("Cherry Bombs", 60);
            bombsInfo.Add("Smoke Decoy Bombs", 120);

            Dictionary<string, int> bombsMade = new Dictionary<string, int>();
            bombsMade.Add("Datura Bombs", 0);
            bombsMade.Add("Cherry Bombs", 0);
            bombsMade.Add("Smoke Decoy Bombs", 0);

            bool areAllBombsCreated = false;
            while (bombEffects.Any() && bombCasing.Any())
            {
                int currentEffect = bombEffects.Dequeue();
                int currentCasing = bombCasing.Pop();

                while (!bombsInfo.ContainsValue(currentEffect + currentCasing))
                {
                    currentCasing -= 5;
                }

                if (bombsInfo.ContainsValue(currentEffect + currentCasing))
                {
                    string currentBomb = bombsInfo.First(b => b.Value == currentEffect + currentCasing).Key;
                    bombsMade[currentBomb]++;
                }

                if (bombsMade.Count == 3 && !bombsMade.Any(b => b.Value < 3))
                {
                    areAllBombsCreated = true;
                    break;
                }
            }

            PrintResult(bombEffects, bombCasing, bombsMade, areAllBombsCreated);
        }

        private static void PrintResult(Queue<int> bombEffects, Stack<int> bombCasing, Dictionary<string, int> bombsMade, bool areAllBombsCreated)
        {
            if (areAllBombsCreated)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (!bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (!bombCasing.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            foreach (var bomb in bombsMade.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
