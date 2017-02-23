using System.IO;
using System.Xml;

namespace SolutionReader
{
    public class DotfuscatorUpdater
    {
        private Solution _solution;

        public string RootDir { get; set; }
        public string SolutionPath { get; set; }
        public string DotfuscatorXmlPath { get; set; }

        public bool Initialize(string slnPath)
        {
            var solution = new Solution();
            solution.LoadFromFile(slnPath);
            if (solution.Projects.Count == 0)
                return false;
            RootDir = Path.GetDirectoryName( Path.GetDirectoryName(slnPath));
            if (string.IsNullOrWhiteSpace(RootDir) || !Directory.Exists(RootDir))
                return false;
            DotfuscatorXmlPath = Path.Combine(RootDir, @"\Encrypt\dotfuscator.xml");
            return File.Exists(DotfuscatorXmlPath);
        }

        public int Update()
        {
            var affectCount = 0;
            var xml = new XmlDocument();
            xml.Load(DotfuscatorXmlPath);
            if (xml.DocumentType != null)
            {
                var name = xml.DocumentType.Name;
                var publicId = xml.DocumentType.PublicId;
                var systemId = xml.DocumentType.SystemId;
                var parent = xml.DocumentType.ParentNode;
                var documentTypeWithNullInternalSubset = xml.CreateDocumentType(name, publicId, systemId, null);
                parent.ReplaceChild(documentTypeWithNullInternalSubset, xml.DocumentType);
            }
            var asmlistNode = xml.SelectSingleNode(@"/dotfuscator/input/asmlist");
            if (asmlistNode == null)
                return affectCount;
            var inputassemblyNode = asmlistNode.ChildNodes[0].Clone();

            asmlistNode.RemoveAll();
            foreach (var project in _solution.Projects)
            {
                var node = inputassemblyNode.Clone();
                if (node.Attributes == null)
                    continue;
                node.Attributes["refid"].Value = project.Id;
                var fileNode = node.SelectSingleNode("file");
                if (fileNode?.Attributes == null)
                    continue;
                fileNode.Attributes["name"].Value = project.GetAssemblyName();
                asmlistNode.AppendChild(node);
                ++affectCount;
            }
            xml.Save(DotfuscatorXmlPath);
            return affectCount;
        }
    }
}