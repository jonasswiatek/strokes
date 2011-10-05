using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Strokes.GUI
{
    public sealed class BoolToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool) 
            {
                     
                return (bool)value
                    ? 1.0
                    : 0.4;
                
            }

            return 0.4;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
