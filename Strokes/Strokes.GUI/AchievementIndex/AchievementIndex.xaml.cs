using System.Windows;
using System.Windows.Media;
using CSharpAchiever.Core;

namespace CSharpAchiever.GUI.AchievementIndex
{
    /// <summary>
    /// Interaction logic for AchievementIndex.xaml
    /// </summary>
    public partial class AchievementIndex : Window
    {
        public AchievementIndex()
        {
            InitializeComponent();

            InitAchievementList();
        }

        private void InitAchievementList()
        {
            AchievementStack.Children.Clear();
            var achievements = AchievementTracker.GetAllAchievementDescriptors();
            foreach (var achievement in achievements)
            {
                var achievementGui = new AchievementGui(achievement)
                                         {
                                             BorderThickness = new Thickness(0, 0, 0, 2),
                                             BorderBrush = Brushes.White
                                         };
                AchievementStack.Children.Add(achievementGui);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AchievementTracker.ResetAchievementProgress();
            InitAchievementList();
        }
    }
}
