using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpfz.Core;

namespace Wpfz
{
    public class Windowz : Window
    {
        /****************** commands ******************/
        public ICommand MyCloseWindowCommand { get; protected set; }
        public ICommand MyMaximizeWindowCommand { get; protected set; }
        public ICommand MyMinimizeWindowCommand { get; protected set; }

        public Windowz()
        {
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //this.Style = this.FindResource("WindowzBaseStyle") as Style; //不带标题
            this.Style = this.FindResource("WindowzDefaultStyle") as Style; ////带标题

            //this.Iconz = (ImageSource)(new ImageSourceConverter().ConvertFrom(Properties.Resources.logo));
            //12=6+6//Margin=6,Border.Effect.BlueRadius=6
            this.MaxHeight = SystemParameters.WorkArea.Height + 12 + 2;

            //bind command
            this.MyCloseWindowCommand = new RoutedUICommand();
            this.BindCommand(MyCloseWindowCommand, (s, e) => {
                this.Close();
            });
            this.MyMaximizeWindowCommand = new RoutedUICommand();
            this.BindCommand(MyMaximizeWindowCommand, (s, e) =>
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                e.Handled = true;
            });
            this.MyMinimizeWindowCommand = new RoutedUICommand();
            this.BindCommand(MyMinimizeWindowCommand, (s, e) => {
                this.WindowState = WindowState.Minimized;
                e.Handled = true;
            });
        }

        //默认Header：窗体图标编码
        public static readonly DependencyProperty IconzProperty = DependencyProperty.Register(
            "Iconz", typeof(string), typeof(Windowz),
            new PropertyMetadata("\ue62e"));
        public string Iconz
        {
            get { return (string)GetValue(IconzProperty); }
            set { SetValue(IconzProperty, value); }
        }

        //默认Header：窗体图标大小
        public static readonly DependencyProperty IconzSizeProperty = DependencyProperty.Register(
            "IconzSize", typeof(double), typeof(Windowz),
            new PropertyMetadata(20D));
        public double IconzSize
        {
            get { return (double)GetValue(IconzSizeProperty); }
            set { SetValue(IconzSizeProperty, value); }
        }

        //CaptionHeight 标题栏高度
        public static readonly DependencyProperty CaptionHeightProperty = DependencyProperty.Register(
            "CaptionHeight", typeof(double), typeof(Windowz),
            new PropertyMetadata(26D));
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        //CaptionBarBackground 标题栏背景色
        public static readonly DependencyProperty CaptionBarBackgroundProperty = DependencyProperty.Register(
            "CaptionBarBackground", typeof(Brush), typeof(Windowz),
            new PropertyMetadata(null));
        public Brush CaptionBarBackground
        {
            get { return (Brush)GetValue(CaptionBarBackgroundProperty); }
            set { SetValue(CaptionBarBackgroundProperty, value); }
        }

        //CaptionBarForeground 标题栏前景色
        public static readonly DependencyProperty CaptionBarForegroundProperty = DependencyProperty.Register(
            "CaptionBarForeground", typeof(Brush), typeof(Windowz),
            new PropertyMetadata(null));
        public Brush CaptionBarForeground
        {
            get { return (Brush)GetValue(CaptionBarForegroundProperty); }
            set { SetValue(CaptionBarForegroundProperty, value); }
        }

        //标题栏内容模板，可自定义
        public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register(
            "TitleTemplate", typeof(ControlTemplate), typeof(Windowz),
            new PropertyMetadata(null));
        public ControlTemplate TitleTemplate
        {
            get { return (ControlTemplate)GetValue(TitleTemplateProperty); }
            set { SetValue(TitleTemplateProperty, value); }
        }

        //MaxboxEnable 是否显示最大化按钮
        public static readonly DependencyProperty MaxboxEnableProperty = DependencyProperty.Register(
            "MaxboxEnable", typeof(bool), typeof(Windowz),
            new PropertyMetadata(true));
        public bool MaxboxEnable
        {
            get { return (bool)GetValue(MaxboxEnableProperty); }
            set { SetValue(MaxboxEnableProperty, value); }
        }

        //MinboxEnable 是否显示最小化按钮
        public static readonly DependencyProperty MinboxEnableProperty = DependencyProperty.Register(
            "MinboxEnable", typeof(bool), typeof(Windowz),
            new PropertyMetadata(true));
        public bool MinboxEnable
        {
            get { return (bool)GetValue(MinboxEnableProperty); }
            set { SetValue(MinboxEnableProperty, value); }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
