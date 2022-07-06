using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OOP_RGR_MVVM.Converters
{
    internal class ViewToViewModelSelectedCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value.ToString() == string.Empty)
            {
                return 0;
            }
            else if (int.TryParse(value.ToString(), out int result))
            {
                return result;
            }
            
            throw new FormatException("С view передано не число!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value.ToString(), out int result))
            {
                var stringResult = result.ToString();

                if (Regex.IsMatch(stringResult, "(?!^[0]$)."))
                    return stringResult;
                else
                    return 0;
            }

            throw new FormatException("С viewmodel передано не число!");
        }
    }
}
