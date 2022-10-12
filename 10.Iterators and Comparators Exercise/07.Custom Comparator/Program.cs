using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _07.CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Comparator comparator = new Comparator();

            integers.Sort(comparator);

            Console.WriteLine(String.Join(" ", integers));
        }

        class Comparator : IComparer<int>
        {

            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                if (x % 2 == 0 && Math.Abs(y) % 2 == 1)
                    return -1;
                if (Math.Abs(x) % 2 == 1 && y % 2 == 0)
                    return 1;
                return x.CompareTo(y);
            }
        }
    }
}
