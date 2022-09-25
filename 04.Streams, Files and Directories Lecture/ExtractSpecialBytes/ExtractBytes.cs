namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> bytes = new List<byte>();

            var reader = new StreamReader(bytesFilePath);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    bytes.Add(byte.Parse(line));
                }
            }

            List<byte> occurences = new List<byte>();

            var binaryBytes = new FileStream(binaryFilePath, FileMode.Open);
            using (binaryBytes)
            {
                byte[] buffer = new byte[binaryBytes.Length];
                binaryBytes.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (bytes.Contains(buffer[i]))
                    {
                        occurences.Add(buffer[i]);
                    }                       
                }
            }
            var outputFile = new FileStream(outputPath, FileMode.Create);
            using (outputFile)
            {
                outputFile.Write(occurences.ToArray(), 0, occurences.Count);
            }
        }
    }
}
