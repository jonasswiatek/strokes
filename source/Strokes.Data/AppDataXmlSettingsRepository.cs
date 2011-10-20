﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Service.Data;
using Strokes.Service.Data.Model;

namespace Strokes.Data
{
    public class AppDataXmlSettingsRepository : AppDataXmlFileRepositoryBase<Settings>, ISettingsRepository
    {
        public AppDataXmlSettingsRepository(string storageFile) : base("Settings.xml")
        {
        }

        public Settings GetSettings()
        {
            return Load();
        }

        public void SaveSettings(Settings settings)
        {
            Save(settings);
        }
    }
}
