using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(GetSum(input, 0));
        }

        private static int GetSum(int[] input, int index)
        {
            if (index == input.Length)
            {
                return 0;
            }
            int result = input[index] + GetSum(input, index + 1);

            return result;
        }
    }
}
