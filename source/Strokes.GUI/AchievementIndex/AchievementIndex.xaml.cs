using System.Windows;
using System.Windows.Media;
using Strokes.Core;
using Strokes.GUI;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System;
using System.Diagnostics;

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
            var achievements = AchievementTracker.GetAllAchievementDescriptors();
            AchievementStack.ItemsSource = achievements;
        }



        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            AchievementTracker.ResetAchievementProgress();
            InitAchievementList();
        }
    }

   
}
