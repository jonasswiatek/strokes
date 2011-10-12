using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core.Data.Model
{
    public class Settings
    {
        public bool EnableInAllProjects { get; set; }
        public string PreferredLocale { get; set; }

        public Settings()
        {
            //Defaults
            EnableInAllProjects = false;
            PreferredLocale = "en"; //Default locale is english.
        }
    }
}
