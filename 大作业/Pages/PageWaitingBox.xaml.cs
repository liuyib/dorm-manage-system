using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpfz;

namespace 大作业.Pages
{
    /// <summary>
    /// PageWaitingBox.xaml 的交互逻辑
    /// </summary>
    public partial class PageWaitingBox : Page
    {
        public PageWaitingBox()
        {
            InitializeComponent();
        }

        private void BtnWaitingBox_Click(object sender, RoutedEventArgs e)
        {
            WaitingBox.Show(() =>
            {
                System.Threading.Thread.Sleep(3000);
            }, "正在加载，请稍后...");
            MessageBoxz.ShowInfo("加载完毕!");
        }

        private void BtnWindowz_Click(object sender, RoutedEventArgs e)
        {
            Windowz w = new Windowz
            {
                Title = "嘿嘿，哈哈，呵呵"
            };
            TextBlock txt = new TextBlock()
            {
                Text = "aaaaaaaaaa",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.Black,
                FontSize = 36
            };
            w.Content = txt;
            w.ShowDialog();
        }
    }
}
