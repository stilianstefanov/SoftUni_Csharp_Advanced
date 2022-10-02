using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            dateModifier.Calculate(firstDate, secondDate);
        }
    }
}
