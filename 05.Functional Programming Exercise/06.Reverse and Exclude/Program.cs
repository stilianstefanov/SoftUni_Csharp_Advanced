﻿using System;
using System.Linq;

namespace _06.Reverse_and_Exclude
{
    internal class Program
    {
        static Func<int, int, bool> isDevisable = (x, y) => x % y != 0;
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ", inputArr
                .Where(x => isDevisable(x, divider))
                .Reverse()));
               
        }
    }
}
