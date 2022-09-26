namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string reportContent = "";
            var folder = new DirectoryInfo(inputFolderPath);
            var fileInfos = folder.GetFiles(inputFolderPath, SearchOption.TopDirectoryOnly);

            SortedDictionary<string, Dictionary<string, double>> info = new SortedDictionary<string, Dictionary<string, double>>();

            foreach (var file in fileInfos)
            {
                string extension = file.Extension;
                string name = file.Name;
                double size = (double)file.Length / 1024;

                if (!info.ContainsKey(extension))
                {
                    info.Add(extension, new Dictionary<string, double>());
                }
                if (!info[extension].ContainsKey(name))
                {
                    info[extension].Add(name, size);
                }
            }

            foreach (var extension in info.OrderByDescending(ext => ext.Value.Count))
            {
                reportContent += extension.Key + "\n";
                foreach (var file in extension.Value.OrderBy(file => file.Value))
                {
                    reportContent += $"--{file.Key} - {file.Value}kb" + "\n";
                }
            }

            return reportContent;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string reportPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

            var writer = new StreamWriter(reportPath + reportFileName);
            using (writer)
            {
                writer.Write(textContent);
            }
        }
    }
}
