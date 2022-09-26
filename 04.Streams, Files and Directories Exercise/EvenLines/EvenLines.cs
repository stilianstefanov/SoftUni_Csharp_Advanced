namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string result = "";
            char[] charsToReplace = { '-', ',', '.', '!', '?' };
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int counter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < charsToReplace.Length; i++)
                        {
                            if (line.Contains(charsToReplace[i]))
                            {
                                line = line.Replace(charsToReplace[i], '@');
                            }
                        }
                        string[] splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();
                        result += $"{string.Join(" ", splittedLine)}\n";
                    }
                    counter++;
                }
            }
            return result;
        }
    }
}
