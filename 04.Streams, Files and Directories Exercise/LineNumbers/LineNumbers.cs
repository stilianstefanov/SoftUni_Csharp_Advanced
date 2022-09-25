namespace LineNumbers
{
    using System;
    using System.IO;

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
                int lettersCnt = 0;
                int marksCnt = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        lettersCnt++;
                    }
                    else if (!char.IsLetter(line[j]) && line[j] != ' ')
                    {
                        marksCnt++;
                    }
                }
                line = line.Insert(0, $"Line {counter}: ");
                line += $"({lettersCnt})({marksCnt})";                
                outputText[i] = line;
                counter++;
            }
            File.WriteAllLines(outputFilePath, outputText);
        }
    }
}
