namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            var reader = new FileStream(sourceFilePath, FileMode.Open);            
            using (reader)
            {
                long fileSize = reader.Length;
                
                if (fileSize % 2 != 0)
                {
                    byte[] firstHalf = new byte[fileSize / 2 + 1];
                    byte[] secondHalf = new byte[fileSize / 2];

                    int firstBytesCount = reader.Read(firstHalf, 0, firstHalf.Length);
                    int secondBytesCount = reader.Read(secondHalf, 0, secondHalf.Length);

                    var firstWriter = new FileStream(partOneFilePath, FileMode.Create);
                    using (firstWriter)
                    {
                        firstWriter.Write(firstHalf, 0, firstBytesCount);
                    }
                    var secondWriter = new FileStream(partTwoFilePath, FileMode.Create);
                    using (secondWriter)
                    {
                        secondWriter.Write(secondHalf, 0, secondBytesCount);
                    }
                }
                else
                {
                    byte[] firstHalf = new byte[fileSize / 2];
                    byte[] secondHalf = new byte[fileSize / 2];

                    int firstBytesCount = reader.Read(firstHalf, 0, firstHalf.Length);
                    int secondBytesCount = reader.Read(secondHalf, 0, secondHalf.Length);

                    var firstWriter = new FileStream(partOneFilePath, FileMode.Create);
                    using (firstWriter)
                    {
                        firstWriter.Write(firstHalf, 0, firstBytesCount);
                    }
                    var secondWriter = new FileStream(partTwoFilePath, FileMode.Create);
                    using (secondWriter)
                    {
                        secondWriter.Write(secondHalf, 0, secondBytesCount);
                    }
                }
            }            
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            List<byte> joinedBytes = new List<byte>();

            var firstReader = new FileStream(partOneFilePath, FileMode.Open);
            using (firstReader)
            {
                byte[] bytes = new byte[firstReader.Length];
                int bytesCount = firstReader.Read(bytes, 0, bytes.Length);

                for (int i = 0; i < bytes.Length; i++)
                {
                    joinedBytes.Add(bytes[i]);
                }
            }
            var secondReader = new FileStream(partTwoFilePath, FileMode.Open);
            using (secondReader)
            {
                byte[] bytes = new byte[secondReader.Length];
                int bytesCount = secondReader.Read(bytes, 0, bytes.Length);

                for (int i = 0; i < bytes.Length; i++)
                {
                    joinedBytes.Add(bytes[i]);
                }
            }
            var writer = new FileStream(joinedFilePath, FileMode.Create);
            using (writer)
            {
                writer.Write(joinedBytes.ToArray(), 0, joinedBytes.Count);
            }
        }
    }
}