using System;

namespace _02.Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactoriel(input));
        }

        private static int GetFactoriel(int input)
        {
            if (input == 1)
            {
                return 1;
            }
            int result = input * GetFactoriel(input - 1);

            return result;
        }
    }
}
