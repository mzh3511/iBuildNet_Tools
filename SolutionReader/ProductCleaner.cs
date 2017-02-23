using System;
using System.Collections.Generic;
using System.IO;

namespace SolutionReader
{
    public class ProductCleaner
    {
        public string RootDir { get; set; }
        public string CleanDir { get; set; }
        public string ProductDir { get; set; }
        public string FileListPath { get; set; }

        public bool Initialize(string productDir)
        {
            ProductDir = productDir;
            RootDir = Path.GetDirectoryName(productDir);
            if (string.IsNullOrWhiteSpace(RootDir) || !Directory.Exists(RootDir))
                return false;

            FileListPath = Path.Combine(RootDir, @"iBuilding\FileList.txt");
            if (!File.Exists(FileListPath))
                return false;

            CleanDir = Path.Combine(RootDir, "CleanProduct");
            return true;
        }

        public int Clean()
        {
            if (Directory.Exists(CleanDir))
            {
                Directory.Delete(CleanDir, true);
            }
            Directory.CreateDirectory(CleanDir);

            var reader = File.OpenText(FileListPath);
            var count = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                if (line.StartsWith("#"))
                    continue;

                if (line.StartsWith("!"))
                    line = line.TrimStart('!');
                if (line.Contains("/"))
                    line = line.Replace("/", "\\");
                var fileArr = new List<string>();
                if (line.Contains("*"))
                {
                    var strArr = line.Split(new[] { "*" }, StringSplitOptions.None);
                    if (strArr.Length == 2)
                    {
                        var dir = Path.Combine(ProductDir, strArr[0]);
                        fileArr.AddRange(Directory.GetFiles(dir, "*" + strArr[1], SearchOption.AllDirectories));
                    }
                    if (strArr.Length == 1)
                    {
                        var dir = Path.Combine(ProductDir, strArr[0]);
                        fileArr.AddRange(Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories));
                    }
                }
                else
                {
                    var filePath = Path.Combine(ProductDir, line);
                    if (File.Exists(filePath))
                        fileArr.Add(filePath);
                }
                foreach (var file in fileArr)
                {
                    var destFile = file.Replace(ProductDir, CleanDir);
                    var destDir = Path.GetDirectoryName(destFile);
                    if (!Directory.Exists(destDir))
                        Directory.CreateDirectory(destDir);
                    File.Copy(file, destFile, true);
                    ++count;
                }
            }
            return count;
        }
    }
}