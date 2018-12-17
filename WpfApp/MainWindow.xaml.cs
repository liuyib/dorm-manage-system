using System;
using System.Windows;
using System.Windows.Controls;
using Wpfz;
using WpfzDemos.Pages;
using WpfzDemos;
using System.Windows.Threading;

namespace 大作业
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        //public static bool b=false;
        public static int time = 0;
        public string Account = "";
        private DispatcherTimer dispatcherTimer;
        public MainWindow(string account_)
        {
            InitializeComponent();
            Account = account_;
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Release\") || dataDir.EndsWith(@"\bin\Debug\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }




            welcome();
            //初始登录界面
            
          //  if(b==false)
            //{
            //    this.SourceInitialized += delegate
            //    {
            //        WpfzDemos.Pages.LoginWindow w = new WpfzDemos.Pages.LoginWindow();
            //        w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //        w.ShowDialog();
            //        if (w.DialogResult == false)
            //        {
            //            App.Current.Shutdown();
            //        }
            //    };
            //}
           

            bodyLayout.Title = "(尚未选择功能)  ";
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            // 当间隔时间过去时发生的事件
            dispatcherTimer.Tick += new EventHandler(ShowCurrentTime);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = null;

            MenuItem item = e.OriginalSource as MenuItem;
            foreach (MenuItem mi in menu1.Items)
            {
                mi.IsChecked = mi == item;
            }
            string skinName = item.Header as string;
            App app = Application.Current as App;
            app.ApplySkin(skinName);
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.OriginalSource as Buttonz;
            bodyLayout.Title = btn.Content.ToString() + "  ";
            this.frame1.Source = new Uri(btn.Tag.ToString(), UriKind.Relative);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("5678");
        }


        private void welcome()
        {

           
            string str_welcome = "";
            DateTime time = new DateTime();
            time = DateTime.Now;
            if (time.Hour >= 0 && time.Hour <= 8)
            {
                str_welcome += "早上好：";
            }
            else if (time.Hour <= 12)
            {
                str_welcome += "上午好：";
            }
            else if (time.Hour <= 18)
            {
                str_welcome += "下午好：";
            }
            else
            {
                str_welcome += "晚上好：";
            }
            Welcome.Content = str_welcome+Account;
           
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            var res = MessageBoxz.ShowQuestion("确定退出？");
            //MessageBoxz.ShowInfo(res.ToString());
            if (res.ToString()=="True")
            {

                App.Current.Shutdown();

            }
            else
            {
                return;
            }
        }

        private void Buttonz_Click_2(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();

            MainWindow mainWindow = new MainWindow("test");
            this.Close();

            loginWindow.ShowDialog();
        }

        private void Buttonz_Click_3(object sender, RoutedEventArgs e)
        {
            ModifyPasswordWindow modifyPasswordWindow = new ModifyPasswordWindow(Account);
            modifyPasswordWindow.Show();
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
