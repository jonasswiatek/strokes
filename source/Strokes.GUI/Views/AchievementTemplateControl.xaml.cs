using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using Strokes.Core.Service.Model;

namespace Strokes.GUI
{
    public partial class AchievementTemplateControl
    {
        public AchievementTemplateControl()
        {
            InitializeComponent();
        }

        public Storyboard FadeInStoryboard
        {
            get
            {
                return (Storyboard)Resources["FadeInStoryboard"];
            }
        }

        public Storyboard FadeOutStoryboard
        {
            get
            {
                return (Storyboard)Resources["FadeOutStoryboard"];
            }
        }

        public Achievement Achievement
        {
            get
            {
                return DataContext as Achievement;
            }
        } 

        private void HintUri_Clicked(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBlock;
            if (textBox != null)
                Process.Start(textBox.Text);
        }

        private void Achievement_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Achievement.HintUri != null)
            {
                if (ExtraInfo.ActualHeight == 0)
                    LayoutRoot.BeginStoryboard(FadeInStoryboard);
                else if (ExtraInfo.ActualHeight == 20)
                    LayoutRoot.BeginStoryboard(FadeOutStoryboard);
            }
        }
    }
}
