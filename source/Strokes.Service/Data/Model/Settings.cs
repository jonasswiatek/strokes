namespace Strokes.Service.Data.Model
{
    public class Settings
    {
        public bool EnableInAllProjects
        {
            get;
            set;
        }

        public string PreferredLocale
        {
            get;
            set;
        }

        public Settings()
        {
            EnableInAllProjects = false;
            PreferredLocale = ""; // Default locale is English.
        }
    }
}
