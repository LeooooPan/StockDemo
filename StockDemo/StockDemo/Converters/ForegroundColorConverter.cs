using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace StockDemo.Converters
{
    public class ForegroundColorConverter : IValueConverter
    {
        //漲跌的顏色變換
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse(value.ToString(), out double result);

            if (result == 0)
            {
                return new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0x00));
            }
            else
            {
                return result > 0 ? new SolidColorBrush(Color.FromArgb(0xFF, 0xDA, 0x4D, 0x4D)) : new SolidColorBrush(Color.FromArgb(0xFF, 0x3D, 0x7C, 0x43));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
