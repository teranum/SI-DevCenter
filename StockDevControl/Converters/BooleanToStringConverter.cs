﻿using System.Globalization;
using System.Windows.Data;

namespace StockDevControl.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? retVals = parameter as string;
            if (retVals != null)
            {
                var true_false = retVals.Split(',');
                if (true_false.Length == 2)
                {
                    return (bool)value ? true_false[1] : true_false[0];
                }
            }
            return "Invalid";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
