using System;
using System.Linq;

namespace _02.Sum_Numbers
{
    internal class Program
    {
        static Action<string[]> print = x => Console.WriteLine($"{x.Length}\r\n{x.Select(int.Parse).Sum()}");
        static void Main(string[] args)
        {
            print(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));            
        }
    }
}
