using System;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    internal class Program
    {
        static Predicate<string> isFirstCapital = w => char.IsUpper(w[0]);
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isFirstCapital(w))
                ));
        }
    }
}
