using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpfz
{
    /// <summary>
    /// 根据背景色获取前景色。当然也可反着用
    /// </summary>
    public class BackgroundToForegroundConverter : IValueConverter
    {
        private Color IdealTextColor(Color bg)
        {
            const int nThreshold = 105;
            var bgDelta = System.Convert.ToInt32((bg.R * 0.299) + (bg.G * 0.587) + (bg.B * 0.114));
            var foreColor = (255 - bgDelta < nThreshold) ? Colors.Black : Colors.White;
            return foreColor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                var idealForegroundColor = this.IdealTextColor(((SolidColorBrush)value).Color);
                var foreGroundBrush = new SolidColorBrush(idealForegroundColor);
                foreGroundBrush.Freeze();
                return foreGroundBrush;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return DependencyProperty.UnsetValue;
            //throw new NotImplementedException();
            if (value is SolidColorBrush)
            {
                var idealBackgroundColor = this.IdealTextColor(((SolidColorBrush)value).Color);
                var backGroundBrush = new SolidColorBrush(idealBackgroundColor);
                backGroundBrush.Freeze();
                return backGroundBrush;
            }
            return Brushes.White;
        }
    }
}
