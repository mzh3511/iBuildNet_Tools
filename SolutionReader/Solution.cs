using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace SolutionReader
{
    public class Solution
    {
        public List<Project> Projects { get; } = new List<Project>();

        public void LoadFromFile(string filePath)
        {
            var sr = new StreamReader(filePath, Encoding.Default);
            var sbPrj = new StringBuilder();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                if (line.StartsWith("Project(", StringComparison.OrdinalIgnoreCase) || sbPrj.Length > 0)
                {
                    sbPrj.AppendLine(line);
                }
                if (line.EndsWith("EndProject", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(sbPrj.ToString());
                    ProcessCsproj(filePath, sbPrj.ToString());
                    sbPrj.Clear();
                }
            }
        }

        private void ProcessCsproj(string slnPath, string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return;
            if (!str.Contains(".csproj") || str.Contains("Test"))
                return;
            var index = str.IndexOf(".csproj", StringComparison.OrdinalIgnoreCase);
            var index1 = str.LastIndexOf('"', index);
            var index2 = str.IndexOf('"', index);
            var strProj = str.Substring(index1 + 1, index2 - index1 - 1);
            var slnDir = Path.GetDirectoryName(slnPath);
            var csprojPath = Path.Combine(slnDir, strProj.Trim());
            if (!File.Exists(csprojPath))
                return;

            var index3 = str.IndexOf('{', index2);
            var index4 = str.IndexOf('}', index2);
            var csprojGuid = str.Substring(index3 + 1, index4 - index3 - 1);

            var project = new Project
            {
                Id = csprojGuid,
                CsprojPath = csprojPath,
            };
            GetAttrFromCsproj(project, csprojPath);

            Projects.Add(project);
        }

        private void GetAttrFromCsproj(Project project, string csprojPath)
        {
            using (var reader = XmlReader.Create(csprojPath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;
                    if (string.IsNullOrEmpty(project.AssemblyName) &&
                        string.Compare(reader.Name, "AssemblyName", StringComparison.OrdinalIgnoreCase) == 0 &&
                        reader.Read())
                    {
                        project.AssemblyName = reader.Value;
                        continue;
                    }
                    if (string.IsNullOrEmpty(project.AssemblyName) &&
                        string.Compare(reader.Name, "OutputType", StringComparison.OrdinalIgnoreCase) == 0 &&
                        reader.Read())
                    {
                        project.OutputType = reader.Value;
                        continue;
                    }

                    if (!string.IsNullOrEmpty(project.AssemblyName) && !string.IsNullOrEmpty(project.OutputType))
                        break;
                }
            }
        }
    }
}