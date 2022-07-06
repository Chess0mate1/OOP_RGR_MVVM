//using RGR_OOP.Logic;

//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows.Data;

namespace RGR_OOP.Converters
{
    //    internal class FullNameConverter : IValueConverter, IMultiValueConverter
    //    {
    //        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //        {
    //            List<string> listValues = (from value in values
    //                             where (value as string) is not null
    //                             select value.ToString()).ToList();

    //            if (listValues.Count() != values.Length)
    //                return null;

    //            foreach (string value in listValues)
    //            {
    //                if (!Regex.IsMatch(value, "^[А-Яа-яЁё]+$"))
    //                    return null;
    //            }

    //            return new FullName()
    //            {
    //                FirstName = listValues[0], LastName = listValues[1], Patronymic = listValues[2]
    //            };
    //        }

    //        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //        {
    //            List<string> listValues = (from value in values
    //                                       where (value as string) is not null
    //                                       select value.ToString()).ToList();

    //            if (listValues.Count() != values.Length)
    //                return null;

    //            foreach (string value in listValues)
    //            {
    //                if (!Regex.IsMatch(value, "^[А-Яа-яЁё]+$"))
    //                    return null;
    //            }

    //            return new FullName()
    //            {
    //                FirstName = listValues[0],
    //                LastName = listValues[1],
    //                Patronymic = listValues[2]
    //            };
    //        }

    //        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
}
