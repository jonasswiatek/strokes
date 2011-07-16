using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Strokes.GUI
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool) 
            {
                if (parameter == null)
                {
                    return (bool)value
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }
                else
                {
                    var equal = bool.Parse(parameter.ToString());

                    return (bool)value == equal
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
