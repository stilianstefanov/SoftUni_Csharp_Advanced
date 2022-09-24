namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordCounts = new Dictionary<string, int>();

            var wordReader = new StreamReader(wordsFilePath);
            using (wordReader)
            {
                string[] wordsLine = wordReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in wordsLine)
                {
                    wordCounts.Add(word.ToLower(), 0);
                }
            }

            var textReader = new StreamReader(textFilePath);
            using (textReader)
            {
                char[] separators = { '-', ',', '.', '?', '!', ':', ';', ' ' };

                string[] text = textReader.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in text)
                {
                    if (wordCounts.ContainsKey(word.ToLower()))
                    {
                        wordCounts[word.ToLower()]++;
                    }
                }
            }
            var textWriter = new StreamWriter(outputFilePath);
            using (textWriter)
            {
                foreach (var map in wordCounts.OrderByDescending(word => word.Value))
                {
                    textWriter.WriteLine($"{map.Key} - {map.Value}");
                }
            }
        }
    }
}
