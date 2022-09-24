namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            using (reader)
            {
                using (writer)
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                    }
                }
                
            }
        }
    }
}
