namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] inputText = File.ReadAllLines(inputFilePath);
            string[] outputText = new string[inputText.Length];

            int counter = 1;
            for (int i = 0; i < inputText.Length; i++)
            {
                string line = inputText[i];
                int lettersCnt = line.Count(ch => char.IsLetter(ch));
                int marksCnt = line.Count(ch => char.IsPunctuation(ch));
                
                line = line.Insert(0, $"Line {counter}: ");
                line += $"({lettersCnt})({marksCnt})";                
                outputText[i] = line;
                counter++;
            }
            File.WriteAllLines(outputFilePath, outputText);
        }
    }
}
