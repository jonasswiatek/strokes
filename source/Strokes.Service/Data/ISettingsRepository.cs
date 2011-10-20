using Strokes.Service.Data.Model;

namespace Strokes.Service.Data
{
    public interface ISettingsRepository
    {
        Settings GetSettings();

        void SaveSettings(Settings settings);
    }
}
