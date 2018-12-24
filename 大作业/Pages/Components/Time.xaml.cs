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
using System.Windows.Threading;

namespace WpfzDemos.Pages
{
    /// <summary>
    /// Time.xaml 的交互逻辑
    /// </summary>
    public partial class Time : Page
    {
        private DispatcherTimer dispatcherTimer;
        public Time()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            // 当间隔时间过去时发生的事件
            dispatcherTimer.Tick += new EventHandler(ShowCurrentTime);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }


        public void ShowCurrentTime(object sender, EventArgs e)
        {
            //获得星期
            //this.tBlockTime.Text = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            //this.tBlockTime.Text += "\n";

            //获得年月日
            //this.tBlockTime.Text = DateTime.Now.ToString("yyyy:MM:dd");   //yyyy年MM月dd日
            //this.tBlockTime.Text += "\n";

            //获得时分秒
            this.tBlockTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
