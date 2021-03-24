using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestApp
{
    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name;

            switch ((string)parameter)
            {
                case "FormatLastFirst":
                    name = $"{values[1]}, {values[0]}"; //이름을 뒤집어서 나오도록 format
                    break;
                case "FortmatNormal":
                    name = $"{values[0]} {values[1]}"; //기본
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            var splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }
}
