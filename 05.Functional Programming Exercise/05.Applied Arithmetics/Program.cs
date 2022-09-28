using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.Applied_Arithmetics
{
    internal class Program
    {
        static Func<int, int> Add = x => ++x;
        static Func<int, int> Subtract = x => --x;
        static Func<int, int> Multiply = x => x * 2;
        static Action<int[]> Print = x => Console.WriteLine(string.Join(" ", x));
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            InputCommand(Console.ReadLine(), numbers);
           
        }

        private static void InputCommand(string command, int[] numbers)
        {
            switch (command)
            {
                case "add":
                    numbers = numbers.Select(x => Add(x)).ToArray();
                    break;
                case "subtract":
                    numbers = numbers.Select(x => Subtract(x)).ToArray();
                    break;
                case "multiply":
                    numbers = numbers.Select(x => Multiply(x)).ToArray();
                    break;
                case "print":
                    Print(numbers);
                    break;
                case "end":
                    return;                    
            }
            InputCommand(Console.ReadLine(), numbers);
        }
    }
}
