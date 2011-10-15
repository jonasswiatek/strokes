using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Data.Model;

namespace Strokes.Core.Data
{
    public interface ISettingsRepository
    {
        Settings GetSettings();

        void SaveSettings(Settings settings);
    }
}
