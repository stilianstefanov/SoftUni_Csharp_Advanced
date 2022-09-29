using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Predicate_Party_
{
    internal class Program
    {

        static Action<List<string>, int> RemoveLength = (l, x) => l.RemoveAll(w => w.Length == x);
        static Action<List<string>, string> RemoveEnd = (l, s) => l.RemoveAll(w => w.EndsWith(s));
        static Action<List<string>, string> RemoveStart = (l, s) => l.RemoveAll(w => w.StartsWith(s));

        static Action<List<string>, string> DoubleStart = (l, s) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].StartsWith(s))
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };
        static Action<List<string>, string> DoubleEnd = (l, s) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].EndsWith(s))
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };
        static Action<List<string>, int> DoubleLength = (l, x) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Length == x)
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };

        static Predicate<List<string>> IsEmpty = l => l.Count == 0;
        static Action<List<string>> Print = l =>
        {
            if (IsEmpty(l))
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", l)} are going to the party!");
            }
        };
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Manipulate(Console.ReadLine(), people);
            Print(people);
        }

        private static void Manipulate(string command, List<string> people)
        {
            if (command.Contains("Remove"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "StartsWith":
                        RemoveStart(people, tokens[2]);
                        break;
                    case "EndsWith":
                        RemoveEnd(people, tokens[2]);
                        break;
                    case "Length":
                        RemoveLength(people, int.Parse(tokens[2]));
                        break;
                }
            }
            else if (command.Contains("Double"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "StartsWith":
                        DoubleStart(people, tokens[2]);
                        break;
                    case "EndsWith":
                        DoubleEnd(people, tokens[2]);
                        break;
                    case "Length":
                        DoubleLength(people, int.Parse(tokens[2]));
                        break;
                }
            }
            else
            {
                return;
            }
            Manipulate(Console.ReadLine(), people);
        }
    }
}
