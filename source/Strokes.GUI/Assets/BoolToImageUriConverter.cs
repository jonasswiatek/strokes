using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Strokes.GUI
{
    public sealed class BoolToImageUriConverter : IValueConverter
    {
        private static Uri CheckedImageUri
            = new Uri("pack://application:,,,/Strokes.GUI;component/Resources/Icons/checked.png");

        private static Uri UncheckedImageUri
            = new Uri("pack://application:,,,/Strokes.GUI;component/Resources/Icons/cross.png");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var image = new BitmapImage();

                try
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

                    if ((bool)value)
                        image.UriSource = CheckedImageUri;
                    else
                        image.UriSource = UncheckedImageUri;

                    image.EndInit();
                }
                catch
                {
                    image = null;
                }

                return image;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
