using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksUsed = 1;
            int clothesSum = 0;

            var clothesInBox = new Stack<int>();
            for (int i = 0; i < clothes.Length; i++)
            {
                clothesInBox.Push(clothes[i]);
            }

            while (clothesInBox.Count > 0)
            {
                int currClothesValue = clothesInBox.Pop();
                clothesSum += currClothesValue;

                if (clothesSum > rackCapacity)
                {
                    racksUsed++;
                    clothesSum = currClothesValue;
                }
                else if (clothesSum == rackCapacity)
                {
                    if (clothesInBox.Count > 0)
                    {
                        racksUsed++;
                        clothesSum = 0;
                    }
                }
            }
            Console.WriteLine(racksUsed);
        }
    }
}
