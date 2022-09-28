using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    internal class Program
    {
        static Func<string[], int> Cmin = arr => arr.Select(int.Parse).Min();
        static void Main(string[] args)
        {
            Console.WriteLine(Cmin(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
