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
    /// PageMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class PageMessageBox : Page
    {
        public PageMessageBox()
        {
            InitializeComponent();
        }

        private void FButton_Click_Error(object sender, RoutedEventArgs e)
        {
            MessageBoxz.ShowError("你只看到我在不停的忙碌，却没看到我奋斗的热情。你有朝九晚五，我有通宵达旦。你否定我的现在，我决定我的未来。你可以轻视我的存在，我会用代码证明这是谁的时代！Coding是注定痛苦的旅行，路上少不了Bug和Change，但！那又怎样！我是程序猿，我为自己带眼");
        }

        private void FButton_Click_Info(object sender, RoutedEventArgs e)
        {
            MessageBoxz.ShowInfo("领域设计、架构设计、技术之路、文明之路");
        }

        private void FButton_Click_Warning(object sender, RoutedEventArgs e)
        {
            MessageBoxz.ShowWarning("架构之美、数学之美、.net 核心框架、异步编程的艺术、单元测试的艺术，代码，WPF");
        }

        private void FButton_Click_Question(object sender, RoutedEventArgs e)
        {
            var res = MessageBoxz.ShowQuestion("你是最帅的嘛？");
            MessageBoxz.ShowInfo(res.ToString());
        }
    }
}
