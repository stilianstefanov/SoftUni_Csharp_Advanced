using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            char[] consonantsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(char.Parse)
               .ToArray();

            Queue<char> vowels = new Queue<char>();
            for (int i = 0; i < vowelsInfo.Length; i++)
            {
                vowels.Enqueue(vowelsInfo[i]);
            }
            Stack<char> consonants = new Stack<char>();
            for (int i = 0; i < consonantsInfo.Length; i++)
            {
                consonants.Push(consonantsInfo[i]);
            }

            Dictionary<string, Dictionary<char, bool>> words = new Dictionary<string, Dictionary<char, bool>>();

            words.Add("pear", new Dictionary<char, bool>());
            words.Add("flour", new Dictionary<char, bool>());
            words.Add("pork", new Dictionary<char, bool>());
            words.Add("olive", new Dictionary<char, bool>());

            foreach (var word in words)
            {
                for (int i = 0; i < word.Key.Length; i++)
                {
                    word.Value.Add(word.Key[i], false);
                }
            }

            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(currentVowel))
                    {
                        word.Value[currentVowel] = true;
                    }
                }
                foreach (var word in words)
                {
                    if (word.Key.Contains(currentConsonant))
                    {
                        word.Value[currentConsonant] = true;
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            List<string> wordsFound = new List<string>();

            foreach (var word in words)
            {
                bool areAllCharsFound = true;
                foreach (var ch in word.Value)
                {
                    if (ch.Value == false)
                    {
                        areAllCharsFound = false;
                        break;
                    }
                }
                if (areAllCharsFound)
                {
                    wordsFound.Add(word.Key);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
