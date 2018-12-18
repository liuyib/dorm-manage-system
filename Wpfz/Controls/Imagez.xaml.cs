using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Wpfz
{
    /// <summary>
    /// Imagez.xaml 的交互逻辑
    /// </summary>
    public partial class Imagez : UserControl
    {
        /// <summary>
        /// 资源设置，支持Iconz图标，例如：&#xe64e;
        /// </summary>
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(string), typeof(Imagez),
            new PropertyMetadata(OnSourcePropertyChanged));

        public TextBlock Iconz { get { return this.iconz; } }
        //public Image image { get { return this.img; } }

        public Imagez()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += delegate { BindSource(this); };
        }

        /// <summary>
        /// 属性更改处理事件
        /// </summary>
        private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (!(sender is Imagez myimg)) return;
            if (!myimg.IsLoaded) return;
            BindSource(myimg);
        }

        private static void BindSource(Imagez sourceImg)
        {
            sourceImg.Iconz.Text = sourceImg.Source;
        }
    }
}
