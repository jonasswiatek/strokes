using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Linq;
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
        private readonly Queue<AchievementDescriptor> _achievementsQueue;

        private static MainAchievementGui _achievementGui = null;

        public MainAchievementGui(IEnumerable<AchievementDescriptor> achievements)
        {
            InitializeComponent();
            _achievementsQueue = new Queue<AchievementDescriptor>(achievements);
            
            if (_achievementsQueue.Count == 0)
                Close();

            PopAchievement();
        }

        public static void DisplayAchievements(IEnumerable<AchievementDescriptor> achievements)
        {
            if (_achievementGui != null) //Aaah:) Singleton pattern. Couldn't figure this one out at forst. Jonas: it's a pretty cheap singleton pattern ;) mostly here to facilitate testing from the Strokes.Console project.
            {
                foreach (var achievement in achievements)
                {
                    _achievementGui._achievementsQueue.Enqueue(achievement);
                }

                if(_achievementGui._achievementsQueue.Count > 0)
                {
                    _achievementGui.PopAchievement();
                }
                
                return;
            }

            _achievementGui = new MainAchievementGui(achievements);

            if (Application.Current != null)
            {
                _achievementGui.Show();       
            }
            else
                new Application().Run(_achievementGui);
        }


        public void PopAchievement()
        {
            var currentAchievement = _achievementsQueue.Dequeue();

            DataContext = currentAchievement;
            Show();

            //by Jonas: Fixed this. The MainAchievementGui.xaml must specify d:DesignHeight="160" d:DesignWidth="290" as attributes for width and height to work (I think the transparent window just assumes some disproportionate size otherwise)
            const int rightMargin = 5;
            const int bottomMargin = rightMargin;

            //Some fancy code, that ensures that the unlocked-box remains within the bounds of visual studio.
            if (Application.Current != null && Application.Current.MainWindow.WindowState == WindowState.Normal) //Visual studio is not maximized, and we need to recalculate bounds.
            {
                var mainWindow = Application.Current.MainWindow;
                Left = mainWindow.Left + mainWindow.Width - Width - rightMargin;
                Top = mainWindow.Top + mainWindow.Height - Height - bottomMargin;
            }
            else
            {
                //Fullscreen mode - but we need to get the height of the system processbar (the width and height doesn't update on the MainWindow when it's manually maximized).
                //Maybe there is something usefull for that on SystemParameters.
                Left = SystemParameters.PrimaryScreenWidth - Width - rightMargin;
                Top = SystemParameters.PrimaryScreenHeight - Height - bottomMargin;
            }

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
                Hide(); //Must be hide, and not show - else any call to show will fail.
            }
            else
                PopAchievement();
        }
    }
}