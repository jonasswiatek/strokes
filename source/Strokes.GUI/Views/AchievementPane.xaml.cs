using GalaSoft.MvvmLight.Messaging;
using Strokes.GUI.ViewModels;
using Strokes.Service.Data;
using StructureMap;
using System.Linq;

namespace Strokes.GUI
{
    public partial class AchievementPane
    {
        private readonly LocalizationViewModel _localizationViewModel = new LocalizationViewModel();
        public AchievementPane()
        {
            InitializeComponent();
            
            Messenger.Default.Register<ResetAchievementsMessage>(this, 
                msg =>
                {
                    AchievementsCategoryListBox.SelectedIndex = 0;
                });

            LanguageSelector.DataContext = _localizationViewModel.AvailableCultures;
            LanguageSelector.SelectionChanged += LanguageSelector_SelectionChanged;
        }

        void LanguageSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var cInfo = e.AddedItems[0] as CultureInfoDto;
            var settingsRepository = ObjectFactory.GetInstance<ISettingsRepository>();
            var settings = settingsRepository.GetSettings();
            settings.PreferredLocale = cInfo.CultureKey;
            settingsRepository.SaveSettings(settings);
        }
    }

    public class ResetAchievementsMessage
    {
    }
}
