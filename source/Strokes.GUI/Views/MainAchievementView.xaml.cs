using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using Strokes.Core;
using Strokes.Core.Model;
using Strokes.GUI.Resources;
using System.ComponentModel;

namespace Strokes.GUI
{
    public partial class MainAchievementView
    {
        private static MainAchievementView achievementView;
        private readonly Queue<AchievementDescriptor> achievementsQueue;
        private DispatcherTimer timer;
        private AchievementDescriptor currentAchievement;

        public MainAchievementView()
        {
            InitializeComponent();
        }

        public MainAchievementView(IEnumerable<AchievementDescriptor> achievements)
        {
            InitializeComponent();

            achievementsQueue = new Queue<AchievementDescriptor>(achievements);

            if (achievementsQueue.Count == 0)
            {
                Close();
            }

            PopAchievement();

            MouseDown += Window_MouseDown;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentAchievement.CodeLocaton != null)
            {
                AchievementContext.OnAchievementClicked(this,
                    new AchievementClickedEventArgs()
                    {
                        AchievementDescriptor = currentAchievement,
                        UIElement = new AchievementViewportControl()
                        {
                            DataContext = currentAchievement
                        }
                    });
            }
        }

        public static void DisplayAchievements(IEnumerable<AchievementDescriptor> achievements)
        {
            if (achievementView != null)
            {
                foreach (var achievement in achievements)
                {
                    achievementView.achievementsQueue.Enqueue(achievement);
                }

                if (achievementView.achievementsQueue.Count > 0)
                {
                    achievementView.PopAchievement();
                }
            }
            else
            {
                achievementView = new MainAchievementView(achievements);

                if (Application.Current != null)
                {
                    achievementView.Show();
                }
                else
                {
                    new Application().Run(achievementView);
                }
            }
        }

        public void PopAchievement()
        {
            this.currentAchievement = achievementsQueue.Dequeue();
            this.DataContext = currentAchievement;
            this.Show();

            const int rightMargin = 5;
            const int bottomMargin = 5;

            if (Application.Current != null &&
                Application.Current.MainWindow.WindowState == WindowState.Normal &&
                Application.Current.MainWindow != this)
            {
                this.Left = Application.Current.MainWindow.Left
                          + Application.Current.MainWindow.Width - Width - rightMargin;

                this.Top = Application.Current.MainWindow.Top
                         + Application.Current.MainWindow.Height - Height - bottomMargin;
            }
            else
            {
                this.Left = SystemParameters.PrimaryScreenWidth - Width - rightMargin;
                this.Top = SystemParameters.MaximizedPrimaryScreenHeight
                         - SystemParameters.ResizeFrameHorizontalBorderHeight - Height - bottomMargin;
            }

            timer = new DispatcherTimer();
            timer.Tick += Timer_Elapsed;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            timer.Stop();

            if (achievementsQueue.Count == 0)
            {
                Hide();
            }
            else
            {
                PopAchievement();
            }
        }
    }
}