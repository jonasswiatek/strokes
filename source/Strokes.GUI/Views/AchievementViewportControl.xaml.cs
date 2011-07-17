using System.Windows;

namespace Strokes.GUI.Resources
{
    public partial class AchievementViewportControl
    {
        public AchievementViewportControl()
        {
            InitializeComponent();
        }

        private void CloseWindowImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //This event doesn't not appear to ever get fired when you click in the CloseWindowImage
            this.Visibility = Visibility.Collapsed;
        }
    }
}
