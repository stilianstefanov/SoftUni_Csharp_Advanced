using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(input);           

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
