namespace Strokes.Core
{
    public class StaticAnalysisManifest
    {
        public string ActiveFile
        {
            get;
            set;
        }

        public string[] CodeFiles
        {
            get;
            set;
        }

        public string[] ChangedFiles
        {
            get;
            set;
        }

        public string ActiveProject
        {
            get;
            set;
        }

        public string ActiveProjectOutputDirectory
        {
            get;
            set;
        }
    }
}