using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Strokes.Core;
using Strokes.Core.Model;
using Strokes.GUI.Resources;

namespace Strokes.GUI
{
    public partial class MainAchievementContainerView
    {
        private List<AchievementDescriptor> achievementDescriptors 
            = new List<AchievementDescriptor>();

        public MainAchievementContainerView()
        {
        }

        public MainAchievementContainerView(IEnumerable<AchievementDescriptor> achievements)
        {
            InitializeComponent();

            foreach (var achivement in achievements)
            {
                achievementDescriptors.Add(achivement); 
            }
            
            foreach (var achivement in achievementDescriptors)
            {
                AchievementGrid.RowDefinitions.Add(new RowDefinition());
            }

            PopAchievements();

            const int rightMargin = 5;

            if (Application.Current != null &&
                Application.Current.MainWindow.WindowState == WindowState.Normal &&
                Application.Current.MainWindow != this)
            {
                Left = Application.Current.MainWindow.Left 
                        + Application.Current.MainWindow.Width - Width - rightMargin;
                Top = Application.Current.MainWindow.Top;
            }
            else
            {
                Left = SystemParameters.PrimaryScreenWidth - Width - rightMargin;
                Top = 0;
            }

            Show();
        }

        private void PopAchievements()
        {
            int i = 0;

            foreach (var achievementDescriptor in achievementDescriptors)
            {
                var achievement = new AchievementTemplateBare();
                var currentAchievement = achievementDescriptor;

                achievement.MouseDown += (sender, args) =>
                {
                    if (currentAchievement.CodeLocaton != null)
                    {
                        AchievementContext.OnAchievementClicked(this, 
                            new AchievementClickedEventArgs
                            {
                                AchievementDescriptor = currentAchievement,
                                UIElement = new AchievementViewportControl()
                                {
                                    DataContext = currentAchievement
                                }
                            });
                    }
                };

                achievement.DataContext = currentAchievement;
                achievement.SetValue(Grid.RowProperty, i++);
                AchievementGrid.Children.Add(achievement);                
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
