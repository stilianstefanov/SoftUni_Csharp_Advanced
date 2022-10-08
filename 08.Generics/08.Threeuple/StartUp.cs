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
            string town = "";
            if (firstLine.Length == 5)
            {
                town = firstLine[3] + " " + firstLine[4];
            }
            else
            {
                town = firstLine[3];
            }

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>();
            firstTuple.Item1 = fullName;
            firstTuple.Item2 = adress;
            firstTuple.Item3 = town;

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isDrunk = false;
            if (secondLine[2] == "drunk")
            {
                isDrunk = true;
            }
            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>();
            secondTuple.Item1 = secondLine[0];
            secondTuple.Item2 = int.Parse(secondLine[1]);
            secondTuple.Item3 = isDrunk;
           

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>();
            thirdTuple.Item1 = thirdLine[0];
            thirdTuple.Item2 = double.Parse(thirdLine[1]);
            thirdTuple.Item3 = thirdLine[2];

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2} -> {firstTuple.Item3}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2} -> {secondTuple.Item3}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2} -> {thirdTuple.Item3}");
        }
    }
}
