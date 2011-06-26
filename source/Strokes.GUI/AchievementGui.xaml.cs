using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Strokes.Core;

namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for Achievement.xaml
    /// </summary>
    public partial class AchievementGui : UserControl
    {
        private readonly AchievementDescriptionAttribute _achievementDescriptor;

        public AchievementGui(AchievementDescriptionAttribute achievementDescriptor)
        {
            InitializeComponent();
            _achievementDescriptor = achievementDescriptor;

            achievement_title.Content = _achievementDescriptor.AchievementTitle;
            achievement_description.Text = _achievementDescriptor.AchievementDescription;

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            var url = achievementDescriptor.IsCompleted
                          ? "/Strokes.GUI;component/480px-symbol_check_svg.png"
                          : "/Strokes.GUI;component/Cross_red_3d.png";
            
            imageSource.UriSource = new Uri(url, UriKind.Relative);
            imageSource.EndInit();

            image1.Source = imageSource;
        }
    }
}