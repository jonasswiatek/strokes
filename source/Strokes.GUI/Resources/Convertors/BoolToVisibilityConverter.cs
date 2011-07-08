using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Strokes.GUI
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        //This converter could be ignored if the viewmodel does the conversion for us (but requires that the viewmodel uses it's own AchievementDesriptor class)
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            if (value != null)
            {
                if ((bool)value)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
