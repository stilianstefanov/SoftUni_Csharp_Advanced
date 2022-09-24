namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] text1 = File.ReadAllLines(firstInputFilePath);
            string[] text2 = File.ReadAllLines(secondInputFilePath);
            
            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                for (int i = 0; i < Math.Min(text1.Length, text2.Length); i++)
                {
                    writer.WriteLine(text1[i]);
                    writer.WriteLine(text2[i]);
                }
                if (text1.Length != text2.Length)
                {
                    if (text1.Length > text2.Length)
                    {
                        for (int i = text2.Length; i < text1.Length; i++)
                        {
                            writer.WriteLine(text1[i]);
                        }
                    }
                    else
                    {
                        for (int i = text1.Length; i < text2.Length; i++)
                        {
                            writer.WriteLine(text2[i]);
                        }
                    }
                }
            }
        }
    }
}
