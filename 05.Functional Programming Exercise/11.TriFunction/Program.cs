using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static Func<string, int, bool> isValid = (s, n) => s.ToCharArray().Sum(ch => (int)ch) >= n;
        static Action<Func<string, int, bool>, string[], int> PrintValid => (f, arr, x) =>
        {
            Console.WriteLine(arr.FirstOrDefault(w => f(w, x)));
        };
        static void Main(string[] args)
        {
            int thresHold = int.Parse(Console.ReadLine());
            PrintValid(isValid, Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries), thresHold);
        }
    }
}
