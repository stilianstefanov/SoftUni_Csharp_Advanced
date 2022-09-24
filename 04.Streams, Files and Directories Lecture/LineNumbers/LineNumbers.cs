namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writher = new StreamWriter(outputFilePath);
            using (reader)
            {
                using (writher)
                {
                    int counter = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writher.WriteLine($"{counter}. {line}");
                        counter++;
                    }
                }
            }
        }
    }
}
