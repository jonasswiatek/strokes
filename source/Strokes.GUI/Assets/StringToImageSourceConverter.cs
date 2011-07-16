using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Strokes.GUI
{
    public sealed class StringToImageSourceConverter : IValueConverter
    {
        private static Uri DefaultImageUri
            = new Uri("pack://application:,,,/Strokes.GUI;component/Resources/Icons/default.png");

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
                    image.UriSource = new Uri(string.Format("pack://application:,,,{0}", value), UriKind.RelativeOrAbsolute);
                    image.EndInit();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    image = null;
                }

                return image;
            }
            else
            {
                return DefaultImageUri;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
