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
using Strokes.Core.Model;
namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class  MainAchievementGui : Window
    {
        private DispatcherTimer _timer;
        private Queue<AchievementDescriptor> _achievementsQueue;

        private static MainAchievementGui _achievementGui = null;

        public MainAchievementGui(IEnumerable<AchievementDescriptor> achievements)
        {
            InitializeComponent();
            _achievementsQueue = new Queue<AchievementDescriptor>(achievements);
            //Align window
            
            if (_achievementsQueue.Count == 0)
                this.Close();

            PopAchievement();
            
        }

        public static void DisplayAchievements(IEnumerable<AchievementDescriptor> achievements)
        {
            if (_achievementGui != null) //Aaah:) Singleton pattern. Couldn't figure this one out at forst.
            {
                foreach (var achievement in achievements)
                {
                    _achievementGui._achievementsQueue.Enqueue(achievement);
                }
                return;
            }

            _achievementGui = new MainAchievementGui(achievements);

            if (Application.Current != null)
                _achievementGui.Show();
            else
                new Application().Run(_achievementGui);
        }


        private void PopAchievement()
        {
           

            var ach = _achievementsQueue.Dequeue();
            ach.IsCompleted = true; //Temporary fix to show the correct icon (better is ISCompleted is set to true before we enter this)
            this.DataContext = ach;

            this.Show();

            this.Top = SystemParameters.PrimaryScreenHeight - 100 -5; //Ugly hardcoding; but somehow not able to get windowdimensions
            this.Left = SystemParameters.PrimaryScreenWidth - 250 -5;
            //Todo bind progress

            _timer = new DispatcherTimer();
            _timer.Tick+=new EventHandler(timer_Elapsed);
            _timer.Interval = new TimeSpan(0, 0, 2);
            _timer.Start();
                     
            
        }


        void timer_Elapsed(object sender, EventArgs e)
        {
            _timer.Stop();
            if (_achievementsQueue.Count == 0)
            {
                this.Close();
            }
            else
                this.PopAchievement();
        }



    }
}