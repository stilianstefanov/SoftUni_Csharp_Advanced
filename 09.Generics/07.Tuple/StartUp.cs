using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = firstLine[0] + " " + firstLine[1];
            string adress = firstLine[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>();
            firstTuple.Item1 = fullName;
            firstTuple.Item2 = adress;

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> secondTuple = new Tuple<string, int>();
            secondTuple.Item1 = secondLine[0];
            secondTuple.Item2 = int.Parse(secondLine[1]);

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> thirdTuple = new Tuple<int, double>();
            thirdTuple.Item1 = int.Parse(thirdLine[0]);
            thirdTuple.Item2 = double.Parse(thirdLine[1]);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}
