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

namespace WpfzDemos.Pages.StayManage
{
    /// <summary>
    /// ChangeStay.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeStay : Page
    {
        public ChangeStay()
        {
            InitializeComponent();
        }

        public void showAdmin()
        {
            var c = new Model1Container();
            var q = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q.ToList();
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            var c = new Model1Container();
            var oldNum = int.Parse(oldNumTextBox.Text.ToString());
            var query = from t in c.StudentInfo where (t.dormNum == oldNum) select t;
            dataGrid.ItemsSource = query.ToList();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            var c = new Model1Container();
            var oldNum = int.Parse(oldNumTextBox.Text.ToString());
            var newNum = int.Parse(newNumTextBox.Text.ToString());
            var linq1 = from z1 in c.StudentInfo where (z1.dormNum == oldNum) select z1;

            foreach (var item in linq1)
            {
                item.dormNum = newNum;
            }

            c.SaveChanges();
            var t = from z in c.StudentInfo where (z.dormNum == newNum) select z;
            dataGrid.ItemsSource = t.ToList();

            add_ok();
        }

        private void add_ok()
        {
            MessageBoxz.ShowInfo("修改成功");
        }


        //private void add_fail()
        //{
        //    MessageBoxz.ShowError("账号和密码不能为空");
        //}
    }
}
