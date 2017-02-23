namespace SolutionReader
{
    public class PathDetail
    {
        public string RootDir { get; private set; }
        public string SlnPath { get; private set; }
        public string FileListPath { get; private set; }
        public string ProductDir { get; private set; }
        public string CleanDir { get; private set; }

        public bool Initialize(string path)
        {
            return true;
        }
    }
}