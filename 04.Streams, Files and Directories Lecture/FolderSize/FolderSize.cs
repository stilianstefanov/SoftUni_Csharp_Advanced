namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            var info = new DirectoryInfo(folderPath);

            long size = info.GetFiles(folderPath,SearchOption.AllDirectories).Length;

            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                writer.Write(size / 1024);
            }
        }
    }
}
