using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Strokes.Core;
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

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                UnlockedAchievementsList.LayoutUpdated += UnlockedAchievementsList_LayoutUpdated;
            }

            achievementService.StaticAnalysisStarted += (sender, args) => DismissNotifications();
        }

        private AchievementNotificationViewModel ViewModel
        {
            get
            {
                return DataContext as AchievementNotificationViewModel;
            }
        }

        private void UnlockedAchievementsList_LayoutUpdated(object sender, EventArgs e)
        {
            CorrectPlacement();

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
                    gotoCodebutton.Visibility = Visibility.Hidden;
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
            DismissNotifications();
        }

        private void DismissNotifications()
        {
            Hide();
            ViewModel.CurrentAchievements.Clear();
        }

        protected void AddAchievements(IEnumerable<Achievement> achievementDescriptors)
        {
            foreach (var achevementDescriptor in achievementDescriptors)
            {
                ViewModel.CurrentAchievements.Add(achevementDescriptor);
            }
        }

        private void CorrectPlacement()
        {
            const int rightMargin = 5;
            const int bottomMargin = 5;

            Owner = Application.Current.MainWindow != this ? Application.Current.MainWindow : Owner;

            if (Owner != null)
            {
                System.Drawing.Rectangle windowRectangle;

                if (Owner.WindowState == WindowState.Maximized)
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

        public void ShowAchievements(IEnumerable<Achievement> achievementDescriptors)
        {
            if (achievementDescriptors == null || !achievementDescriptors.Any())
            {
                return;
            }

            isEventsBound = false;
            AddAchievements(achievementDescriptors);

            if (Application.Current != null)
            {
                Show();
            }
            else
            {
                // When activated from a console-app, this is called.
                new Application().Run(this);
            }
        }
    }
}