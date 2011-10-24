using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Service.Data;
using Strokes.Service.Data.Model;

namespace Strokes.Data
{
    public class AppDataXmlSettingsRepository : AppDataXmlFileRepositoryBase<Settings>, ISettingsRepository
    {
        public AppDataXmlSettingsRepository(string storageFile) : base(storageFile)
        {
        }

        public Settings GetSettings()
        {
            var settings = Load();
            return settings ?? new Settings();
        }

        public void SaveSettings(Settings settings)
        {
            Save(settings);
        }
    }
}
