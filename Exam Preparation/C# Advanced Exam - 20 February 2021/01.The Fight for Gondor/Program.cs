using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01.The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            int[] defensesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(defensesInfo);
            Stack<int> orcs = new Stack<int>();
            int plate = plates.Peek();

            for (int wave = 1; wave <= numberOfWaves; wave++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (wave % 3 == 0)
                    plates.Enqueue(int.Parse(Console.ReadLine()));

                int orc = orcs.Peek();
                while (orcs.Any() && plates.Any())
                {
                    int damage = Math.Min(plate, orc);
                    plate -= damage;
                    orc -= damage;
                    if (orc == 0)
                    {
                        orcs.Pop();
                        if (orcs.Any()) 
                            orc = orcs.Peek();
                    }
                    if (plate == 0)
                    {
                        plates.Dequeue();
                        if (plates.Any()) 
                            plate = plates.Peek();
                    }
                }
                if (!plates.Any())
                {
                    orcs.Pop();
                    orcs.Push(orc);
                    break;
                }
            }

            if (plates.Any())
            {
                List<int> platesLeft = new List<int>(plates);
                platesLeft[0] = plate;
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesLeft)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}

