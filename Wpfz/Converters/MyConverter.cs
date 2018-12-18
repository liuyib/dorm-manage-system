using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpfz
{
    /// <summary>
    /// 常用转换器的静态引用
    /// 使用示例：Converter={x:Static local:MyConverter.TrueToFalseConverter}
    /// </summary>
    public sealed class MyConverter
    {
        public static BooleanToVisibilityConverter BooleanToVisibilityConverter { get; } = new BooleanToVisibilityConverter();
        public static TrueToFalseConverter TrueToFalseConverter { get; } = new TrueToFalseConverter();
        public static ThicknessToDoubleConverter ThicknessToDoubleConverter { get; } = new ThicknessToDoubleConverter();
        public static BackgroundToForegroundConverter BackgroundToForegroundConverter { get; } = new BackgroundToForegroundConverter();
        public static TreeViewMarginConverter TreeViewMarginConverter { get; } = new TreeViewMarginConverter();
        public static PercentToAngleConverter PercentToAngleConverter { get; } = new PercentToAngleConverter();
        public static UriSourceToBitmapImageConverter UriSourceToBitmapImageConverter { get; } = new UriSourceToBitmapImageConverter();
    }
}
