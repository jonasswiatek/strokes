using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Linq;
using CSharpAchiever.GUI;
using CSharpAchiever.GUI.AchievementIndex;
using Strokes.Core;

namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class  MainAchievementGui : Window
    {
        private Timer timer;
        private int closeTimeout = 6000;
        private int currentTime;
        private int interval = 200;

        private Queue<Achievement> achievementQueue;

        private static MainAchievementGui _achievementGui = null;

        public MainAchievementGui(IEnumerable<Achievement> achievements)
        {
            InitializeComponent();

            Opacity = 0;

            //Align window
            Left = 50;
            Top = SystemParameters.PrimaryScreenHeight - Height - 100;

            //Click in window close feature
            MouseDown += AchievementMouseDown;

            //Create achievement queue
            achievementQueue = new Queue<Achievement>(achievements);
            if(achievementQueue.Count == 0)
            {
                CloseWindow();
            }

            //Pop first achievement
            PopAchievement();
        }

        public static void DisplayAchievements(IEnumerable<Achievement> achievements)
        {
            if(_achievementGui != null)
            {
                foreach(var achievement in achievements)
                {
                    if(!_achievementGui.achievementQueue.Any(a => a.GetAchievementDescriptor().AchievementTitle == achievement.GetAchievementDescriptor().AchievementTitle))
                    {
                        _achievementGui.achievementQueue.Enqueue(achievement);
                    }
                }

                return; //return out, app is already running and the required stuff has been enqueued
            }

            _achievementGui = new MainAchievementGui(achievements);

            if (Application.Current != null)
            {
                _achievementGui.Show();
            }
            else
            {
                new Application().Run(_achievementGui);
            }
        }

        private void PopAchievement()
        {
            #region Fade out/in

            var storyboard = new Storyboard();
            var duration = new TimeSpan(0, 0, 0, 0, 500);

            var fadeOut = new DoubleAnimation { From = 1.0, To = 0.0, Duration = new Duration(duration) };
            var fadeIn = new DoubleAnimation { From = 0.0, To = 1.0, Duration = new Duration(duration) };

            Storyboard.SetTarget(fadeOut, this);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath(OpacityProperty));

            Storyboard.SetTarget(fadeIn, this);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));

            if (Opacity > 0.0)
            {
                storyboard.Children.Add(fadeOut);
                fadeIn.BeginTime = duration; //offset fadein
            }
            storyboard.Children.Add(fadeIn);
            storyboard.Begin(this);

            #endregion

            achievement_stackPanel.Children.Clear();
            var ach = achievementQueue.Dequeue();

            var descriptor = ach.GetAchievementDescriptor();
            AchievementTracker.RegisterAchievementCompleted(descriptor);

            var achievement = new AchievementGui(descriptor);
            achievement_stackPanel.Children.Add(achievement);

            //Set progress info
            var allAchievements = AchievementTracker.GetAllAchievementDescriptors();
            var completed = allAchievements.Count(a => a.IsCompleted);
            var total = allAchievements.Count();

            var text = completed + " of " + total + " completed";
            achievementProgress_label.Content = text;

            timer = new Timer(TimeOut, this, interval, interval);
        }

        void AchievementMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTime = closeTimeout;
        }

        private void CloseWindow()
        {
            _achievementGui = null;
            Close();
        }

        private void TimeOut(object state)
        {
            currentTime = currentTime + interval;

            Console.WriteLine(currentTime);

            if (currentTime >= closeTimeout)
            {
                timer.Change(int.MaxValue, int.MaxValue);
                if(achievementQueue.Count == 0)
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(CloseWindow));
                }
                else
                {
                    currentTime = 0;
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(PopAchievement));
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var achievementIndex = new AchievementIndex();
            achievementIndex.Show();
        }
    }
}