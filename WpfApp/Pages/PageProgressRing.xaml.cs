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

namespace 大作业
{
    /// <summary>
    /// Page_Waiting.xaml 的交互逻辑
    /// </summary>
    public partial class PageProgressRing : Page
    {
        private IAsynNotify asyn;
        public PageProgressRing()
        {
            InitializeComponent();

            this.asyn = new DefaultAsynNotify();
            this.pro1.DataContext = this.asyn;
            this.pro2.DataContext = this.asyn;

            this.pro3.DataContext = this.asyn;

            this.pro4.DataContext = this.asyn;
            this.pro5.DataContext = this.asyn;
            this.pro6.DataContext = this.asyn;
            this.proValue.DataContext = this.asyn;
        }

        private async void BtnxSuccess_Click(object sender, RoutedEventArgs e)
        {
            this.asyn.Start(100);
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    this.asyn.Advance(1);
                    System.Threading.Thread.Sleep(50);
                }
                this.asyn.IsSuccess = true;
            });
        }

        private async void BtnxFail_Click(object sender, RoutedEventArgs e)
        {
            this.asyn.Start(100);
            await Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    this.asyn.Advance(1);
                    System.Threading.Thread.Sleep(50);
                    if (i >= 30)
                    {
                        this.asyn.Cancel();
                        this.asyn.IsSuccess = false;
                        break;
                    }
                }
            });
        }

        private void BtnxReset_Click(object sender, RoutedEventArgs e)
        {
            this.asyn.Start(0);
        }
    }
}
