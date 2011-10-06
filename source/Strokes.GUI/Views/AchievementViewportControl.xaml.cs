﻿using System.Windows;

namespace Strokes.GUI
{
    public partial class AchievementViewportControl
    {
        public AchievementViewportControl()
        {
            InitializeComponent();
        }

        private void CloseWindowImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
