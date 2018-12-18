using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Wpfz
{
    public class Buttonz : System.Windows.Controls.Button
    {
        static Buttonz()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Buttonz),
                new FrameworkPropertyMetadata(typeof(Buttonz))
            );
        }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register(
            "PressedBackground",
            typeof(Brush),
            typeof(Buttonz),
            new PropertyMetadata(Brushes.DarkBlue));
        /// <summary>
        /// 鼠标按下背景样式
        /// </summary>
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.Register(
            "PressedForeground",
            typeof(Brush), typeof(Buttonz),
            new PropertyMetadata(Brushes.White));
        /// <summary>
        /// 鼠标按下前景样式（图标、文字）
        /// </summary>
        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground",
            typeof(Brush), typeof(Buttonz),
            new PropertyMetadata(Brushes.RoyalBlue));
        /// <summary>
        /// 鼠标进入背景样式
        /// </summary>
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground",
                typeof(Brush), typeof(Buttonz),
                new PropertyMetadata(Brushes.White));
        /// <summary>
        /// 鼠标进入前景样式
        /// </summary>
        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty IconzProperty = DependencyProperty.Register(
            "Iconz", typeof(string), typeof(Buttonz),
            new PropertyMetadata("\ue019"));
        /// <summary>
        /// 按钮的图标编码
        /// </summary>
        public string Iconz
        {
            get { return (string)GetValue(IconzProperty); }
            set { SetValue(IconzProperty, value); }
        }

        public static readonly DependencyProperty IconzSizeProperty =
            DependencyProperty.Register("IconzSize", typeof(int), typeof(Buttonz),
            new PropertyMetadata(20));
        /// <summary>
        /// 按钮的图标大小
        /// </summary>
        public int IconzSize
        {
            get { return (int)GetValue(IconzSizeProperty); }
            set { SetValue(IconzSizeProperty, value); }
        }

        public static readonly DependencyProperty IconzMarginProperty = DependencyProperty.Register(
            "IconzMargin", typeof(Thickness), typeof(Buttonz),
            new PropertyMetadata(new Thickness(0, 1, 3, 1)));
        /// <summary>
        /// 字体图标间距
        /// </summary>
        public Thickness IconzMargin
        {
            get { return (Thickness)GetValue(IconzMarginProperty); }
            set { SetValue(IconzMarginProperty, value); }
        }

        public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.Register(
            "AllowsAnimation", typeof(bool), typeof(Buttonz),
            new PropertyMetadata(true));
        /// <summary>
        /// 是否启用Iconz动画
        /// </summary>
        public bool AllowsAnimation
        {
            get { return (bool)GetValue(AllowsAnimationProperty); }
            set { SetValue(AllowsAnimationProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius),
            typeof(Buttonz), new PropertyMetadata(new CornerRadius(5)));
        /// <summary>
        /// 按钮圆角大小:左上，右上，右下，左下
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty ContentDecorationsProperty = DependencyProperty.Register(
            "ContentDecorations", typeof(TextDecorationCollection),
            typeof(Buttonz), new PropertyMetadata(null));
        public TextDecorationCollection ContentDecorations
        {
            get { return (TextDecorationCollection)GetValue(ContentDecorationsProperty); }
            set { SetValue(ContentDecorationsProperty, value); }
        }

    }

}
