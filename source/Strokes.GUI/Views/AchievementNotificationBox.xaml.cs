using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Strokes.Core;
using Strokes.Core.Model;
using Strokes.GUI.Resources;

namespace Strokes.GUI.Views
{
    /// <summary>
    /// Interaction logic for AchievementNotificationBox.xaml
    /// </summary>
    public partial class AchievementNotificationBox : Window
    {
        private bool _isEventsBound;
        public AchievementNotificationBox()
        {
            InitializeComponent();

            this.CurrentAchievements = new ObservableCollection<AchievementDescriptor>();
            this.DataContext = CurrentAchievements;
            UnlockedAchievementsList.LayoutUpdated += new EventHandler(UnlockedAchievementsList_LayoutUpdated);
        }

        protected ObservableCollection<AchievementDescriptor> CurrentAchievements
        {
            get;
            set;
        }

        void UnlockedAchievementsList_LayoutUpdated(object sender, EventArgs e)
        {
            if (_isEventsBound)
                return;

            _isEventsBound = true;

            foreach (AchievementDescriptor item in UnlockedAchievementsList.Items)
            {
                var dataItem = item;
                var gotoCodebutton = FindItemControl(UnlockedAchievementsList, "GotoSource", item) as Image;
                if(gotoCodebutton == null)
                    continue;

                if(dataItem.CodeLocaton == null)
                {
                    gotoCodebutton.IsEnabled = false;
                }
                else
                {
                    gotoCodebutton.MouseDown += (se, args) =>
                    {
                        var achevementDescriptor = dataItem;

                        AchievementContext.OnAchievementClicked(gotoCodebutton, new AchievementClickedEventArgs
                        {
                            AchievementDescriptor = achevementDescriptor,
                            UIElement = new AchievementViewportControl()
                            {
                                DataContext = achevementDescriptor
                            }
                        });
                    };
                }
            }
        }

        private static object FindItemControl(ItemsControl itemsControl, string controlName, object item)
        {
            var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
            container.ApplyTemplate();
            return container.ContentTemplate.FindName(controlName, container);
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

                if (Application.Current.MainWindow.WindowState == WindowState.Normal && Application.Current.MainWindow != instance)
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