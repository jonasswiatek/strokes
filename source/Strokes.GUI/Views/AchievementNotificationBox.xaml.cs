using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Strokes.Core;
using System.ComponentModel;
using System.Windows.Shapes;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;
using StructureMap;
using Application = System.Windows.Application;

namespace Strokes.GUI.Views
{
    /// <summary>
    /// Interaction logic for AchievementNotificationBox.xaml
    /// </summary>
    public partial class AchievementNotificationBox : Window
    {
        private bool isEventsBound = false;

        public AchievementNotificationBox(IAchievementService achievementService)
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this) == false)
            {
                UnlockedAchievementsList.LayoutUpdated += UnlockedAchievementsList_LayoutUpdated;
            }

            //achievementService.StaticAnalysisStarted += (sender, args) => Close();
        }

        private AchievementNotificationViewModel ViewModel
        {
            get
            {
                return DataContext as AchievementNotificationViewModel;
            }
        }

        /// <summary>
        /// Locates the magnifying glass inside the templates, and binds an event to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnlockedAchievementsList_LayoutUpdated(object sender, EventArgs e)
        {
            if (isEventsBound)
                return;

            isEventsBound = true;

            foreach (Achievement item in UnlockedAchievementsList.Items)
            {
                var dataItem = item;
                var gotoCodebutton = FindItemControl(UnlockedAchievementsList, "PART_MagnifierGlassPath", item) as FrameworkElement;

                if (gotoCodebutton == null)
                {
                    continue;
                }

                if (dataItem.CodeOrigin == null)
                {
                    gotoCodebutton.IsEnabled = false;
                }
                else
                {
                    gotoCodebutton.MouseDown += (se, args) =>
                    {
                        var achevementDescriptor = dataItem;

                        AchievementUIContext.OnAchievementClicked(gotoCodebutton, new AchievementClickedEventArgs
                        {
                            AchievementDescriptor = achevementDescriptor,
                            UIElement = new AchievementViewportControl
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

        private void CloseWindowImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        protected void AddAchievements(IEnumerable<Achievement> achievementDescriptors)
        {
            foreach (var achevementDescriptor in achievementDescriptors)
            {
                ViewModel.CurrentAchievements.Add(achevementDescriptor);
            }
        }

        public void ShowAchievements(IEnumerable<Achievement> achievementDescriptors)
        {
            if (achievementDescriptors == null || !achievementDescriptors.Any())
            {
                return;
            }

            AddAchievements(achievementDescriptors);

            if (Application.Current != null)
            {
                const int rightMargin = 5;
                const int bottomMargin = 5;

                Owner = Application.Current.MainWindow != this ? Application.Current.MainWindow : Owner;
                Show();

                if (Owner != null)
                {
                    System.Drawing.Rectangle windowRectangle;

                    if (Owner.WindowState == System.Windows.WindowState.Maximized)
                    {
                        windowRectangle = System.Windows.Forms.Screen.GetWorkingArea(
                            new System.Drawing.Point((int)Owner.Left, (int)Owner.Top));
                    }
                    else
                    {
                        windowRectangle = new System.Drawing.Rectangle(
                            (int)Owner.Left, 
                            (int)Owner.Top, 
                            (int)Owner.ActualWidth, 
                            (int)Owner.ActualHeight);
                    }

                    Left = windowRectangle.Left + windowRectangle.Width - Width - rightMargin;
                    Top = windowRectangle.Top + windowRectangle.Height - Height - bottomMargin;
                }
            }
            else
            {
                // When activated from a console-app, this is called.
                new Application().Run(this);
            }
        }
    }
}