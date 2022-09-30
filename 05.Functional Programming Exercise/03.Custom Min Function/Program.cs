using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    internal class Program
    {
        static Func<string[], int> cmin = arr => arr.Select(int.Parse).Min();
        static void Main(string[] args)
        {
            Console.WriteLine(cmin(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
