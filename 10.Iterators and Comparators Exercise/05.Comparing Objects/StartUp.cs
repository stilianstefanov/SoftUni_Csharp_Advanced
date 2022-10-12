using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string info;
            while ((info = Console.ReadLine()) != "END")
            {
                string[] tokens = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            int requiredIndex = int.Parse(Console.ReadLine());

            int countOfMatches = 0;
            int countOfNotMatches = 0;
            int totalNumber = people.Count;

            var personToCompare = people[requiredIndex - 1];

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotMatches} {totalNumber}");
            }
        }
    }
}
