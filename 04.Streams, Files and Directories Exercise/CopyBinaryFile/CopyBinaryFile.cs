namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var reader = new FileStream(inputFilePath, FileMode.Open);
            using (reader)
            {
                var writer = new FileStream(outputFilePath, FileMode.Create);
                using (writer)
                {
                    byte[] buffer = new byte[reader.Length];
                    int bytesCount = reader.Read(buffer, 0, buffer.Length);

                    writer.Write(buffer, 0, bytesCount);
                }
            }
        }
    }
}
