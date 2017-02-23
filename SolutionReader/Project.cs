using System.Diagnostics;

namespace SolutionReader
{
    [DebuggerDisplay("{AssemblyName}")]
    public class Project
    {
        public string Id { get; set; }
        public string CsprojPath { get; set; }
        public string OutputType { get; set; }
        public string AssemblyName { get; set; }

        public string GetAssemblyName()
        {
            var ext = OutputType == "Library" ? ".dll" : ".exe";
            return AssemblyName + ext;
        }
    }
}