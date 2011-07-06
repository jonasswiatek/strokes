using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for AchievementTemplate.xaml
    /// </summary>
    public partial class AchievementTemplate : UserControl
    {
        public AchievementTemplate()
        {
            InitializeComponent();
        }
    }

    public sealed class BoolToImageUriConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage image = new BitmapImage();
            if (value != null)
            {
                try
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

                    if ((bool)value)
                        image.UriSource = new System.Uri("pack://application:,,,/Strokes.GUI;component/Icons/checked.png");
                    else
                        image.UriSource = new System.Uri("pack://application:,,,/Strokes.GUI;component/Icons/cross.png");

                    image.EndInit();
                }
                catch
                {
                    image = null;
                }
            }
            return image;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
