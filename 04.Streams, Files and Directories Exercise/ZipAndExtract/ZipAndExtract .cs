﻿namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);
            using (archive)
            {
                archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Read);
            using (archive)
            {
                archive.GetEntry(fileName).ExtractToFile(outputFilePath);
            }
        }
    }
}
