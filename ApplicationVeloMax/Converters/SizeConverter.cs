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
            //Subtract 1, otherwise we could overflow to two rows.
            return 0.16666667 * width - 1; // Returns a quarter
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
