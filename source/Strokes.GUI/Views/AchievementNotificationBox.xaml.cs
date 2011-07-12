using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Strokes.Core.Model;

namespace Strokes.GUI.Views
{
    /// <summary>
    /// Interaction logic for AchievementNotificationBox.xaml
    /// </summary>
    public partial class AchievementNotificationBox : Window
    {
        //Static singleton-like instance
        protected static AchievementNotificationBox Instance;
        protected ObservableCollection<AchievementDescriptor> CurrentAchievements = new ObservableCollection<AchievementDescriptor>();

        public AchievementNotificationBox()
        {
            InitializeComponent();

            //Bind some shit
            DataContext = CurrentAchievements;
        }

        private void CloseWindowImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentAchievements.Clear();
            Hide();
        }

        protected void AddAchievements(IEnumerable<AchievementDescriptor> achievementDescriptors)
        {
            foreach(var achevementDescriptor in achievementDescriptors)
            {
                CurrentAchievements.Add(achevementDescriptor);
            }

            if (!IsVisible && CurrentAchievements.Count > 0)
            {
                //This is only to support the Strokes.Console-project
                if (Application.Current != null)
                {
                    //During a real Visual Studio integrated run, this is called.
                    Show();
                }
                else
                {
                    //When activated from a console-app, this is called.
                    new Application().Run(this);
                }

                /* When this code is left in, it seems to only work the first time. I think it requires to be syncronized with when the ListBox is done layouting.
                const int rightMargin = 5;
                const int bottomMargin = 5;

                if (Application.Current != null && Application.Current.MainWindow.WindowState == WindowState.Normal && Application.Current.MainWindow != this)
                {
                    Left = Application.Current.MainWindow.Left + Application.Current.MainWindow.Width - Width - rightMargin;
                    Top = Application.Current.MainWindow.Top + Application.Current.MainWindow.Height - Height - bottomMargin;
                }
                else
                {
                    Left = SystemParameters.PrimaryScreenWidth - Width - rightMargin;
                    Top = SystemParameters.MaximizedPrimaryScreenHeight - SystemParameters.ResizeFrameHorizontalBorderHeight - Height - bottomMargin;
                }
                 * */
            }
        }

        public static void ShowAchievements(IEnumerable<AchievementDescriptor> achievementDescriptors)
        {
            if(achievementDescriptors.Count() <= 0)
                return;

            /*
             * If we don't have a singleton instance active - then create one.
             * We need this, if more achievements gets unlocked while this box is still showing.
             */
            if(Instance == null)
            {
                Instance = new AchievementNotificationBox();
            }

            Instance.AddAchievements(achievementDescriptors);
        }
    }
}