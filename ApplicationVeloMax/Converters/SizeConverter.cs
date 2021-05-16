using System;
using System.Windows.Data;

namespace ApplicationVeloMax.Converters
{
    public class SizeConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double width = Double.Parse(value.ToString());
            return 0.2 * width - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
