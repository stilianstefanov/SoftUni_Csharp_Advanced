using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12.Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottlesInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesInfo);
            Queue<int> cups = new Queue<int>(cupsInfo);

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    int currCupCapacity = cups.Dequeue();
                    int currBottleWater = bottles.Pop();

                    int currWastedWater = currBottleWater - currCupCapacity;
                    wastedWater += currWastedWater;
                }
                else
                {
                    int currCupCapacity = cups.Dequeue();
                    while (currCupCapacity > 0)
                    {
                        int currBottleWater = bottles.Pop();

                        currCupCapacity -= currBottleWater;

                        if (currCupCapacity <= 0)
                        {
                            int currWastedWater = Math.Abs(currCupCapacity);
                            wastedWater += currWastedWater;
                        }
                    }
                }
            }

            if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
