using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Strokes.Core;
using Strokes.Core.Model;

namespace Strokes.GUI.Views
{
    /// <summary>
    /// Interaction logic for AchievementNotificationBox.xaml
    /// </summary>
    public partial class AchievementNotificationBox : Window
    {
        public AchievementNotificationBox()
        {
            InitializeComponent();

            this.CurrentAchievements = new ObservableCollection<AchievementDescriptor>();
            this.DataContext = CurrentAchievements;

            AchievementContext.AchievementDetectionStarting += AchievementContext_AchievementDetectionStarting;
        }

        protected ObservableCollection<AchievementDescriptor> CurrentAchievements 
        {
            get;
            set;
        }

        private void AchievementContext_AchievementDetectionStarting(object sender, System.EventArgs e)
        {
            Close();
        }

        private void CloseWindowImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        protected void AddAchievements(IEnumerable<AchievementDescriptor> achievementDescriptors)
        {
            foreach (var achevementDescriptor in achievementDescriptors)
            {
                CurrentAchievements.Add(achevementDescriptor);
            }
        }

        public static void ShowAchievements(IEnumerable<AchievementDescriptor> achievementDescriptors)
        {
            if (achievementDescriptors.Any() == false)
            {
                return;
            }
            
            var instance = new AchievementNotificationBox();
            instance.AddAchievements(achievementDescriptors);

            // This is only to support the Strokes.Console-project
            if (Application.Current != null)
            {
                // During a real Visual Studio integrated run, this is called.
                instance.Show();

                const int rightMargin = 5;
                const int bottomMargin = 5;

                if (Application.Current != null && Application.Current.MainWindow.WindowState == WindowState.Normal && Application.Current.MainWindow != instance)
                {
                    instance.Left = Application.Current.MainWindow.Left + Application.Current.MainWindow.Width - instance.Width - rightMargin;
                    instance.Top = Application.Current.MainWindow.Top + Application.Current.MainWindow.Height - instance.Height - bottomMargin;
                }
                else
                {
                    instance.Left = SystemParameters.PrimaryScreenWidth - instance.Width - rightMargin;
                    instance.Top = SystemParameters.MaximizedPrimaryScreenHeight - SystemParameters.ResizeFrameHorizontalBorderHeight - instance.Height - bottomMargin;
                }
            }
            else
            {
                // When activated from a console-app, this is called.
                new Application().Run(instance);
            }
        }
    }
}