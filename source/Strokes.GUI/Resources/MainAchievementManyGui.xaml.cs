using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Strokes.Core;
using Strokes.Core.Model;
using Strokes.GUI.Resources;

namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for MainAchievementManyGui.xaml
    /// </summary>
    public partial class MainAchievementManyGui : Window
    {
        private List<AchievementDescriptor> _achievements = new List<AchievementDescriptor>();

        public MainAchievementManyGui(IEnumerable<AchievementDescriptor> achievements)
        {
            InitializeComponent();
 
            foreach (var ach in achievements)
            {
                _achievements.Add(ach); 
            }
            //Prepare grid
            
            for (int i = 0; i < _achievements.Count; i++)
            {
                achievementgrid.RowDefinitions.Add(new RowDefinition());
            }

            //Show achievements
            PopAchievements();

            //Place at a good spot
            const int rightMargin = 5;
            const int bottomMargin = rightMargin;

          
            if (Application.Current != null && Application.Current.MainWindow.WindowState == WindowState.Normal && Application.Current.MainWindow != this) //Visual studio is not maximized, and we need to recalculate bounds.
            {
                var mainWindow = Application.Current.MainWindow;
                Left = mainWindow.Left + mainWindow.Width - Width - rightMargin;
                Top = mainWindow.Top ;
            }
            else
            {
                //Fullscreen mode. Adjusts for processbar and frame-borders.
                Left = SystemParameters.PrimaryScreenWidth - Width - rightMargin;
                Top = 0;
            }
            
            this.Show();
        }

        private void PopAchievements()
        {
            int i = 0;

            foreach (var achievementDescriptor in _achievements)
            {
                var achievement = new AchievementTemplateBare();
                var currentAchievement = achievementDescriptor; //Modified closure - this is needed because of the lambda expression below.

                achievement.MouseDown += (sender, args) =>
                                             {
                                                 if (currentAchievement.CodeLocaton != null)
                                                 {
                                                     var achievementFloatingControl = new AchievementMiniControl();
                                                     achievementFloatingControl.DataContext = currentAchievement;

                                                     AchievementContext.OnAchievementClicked(this, new AchievementClickedEventArgs
                                                                                                     {
                                                                                                         AchievementDescriptor = currentAchievement,
                                                                                                         UIElement = achievementFloatingControl
                                                                                                     });
                                                 }
                                             };

                achievement.DataContext = currentAchievement;
                achievement.SetValue(Grid.RowProperty, i);
                achievementgrid.Children.Add(achievement);
                i++;
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
