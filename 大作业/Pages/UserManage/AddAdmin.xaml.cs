using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;

namespace WpfzDemos.Pages
{
    /// <summary>
    /// AddAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class AddAdmin : Page
    {
        public AddAdmin()
        {
            InitializeComponent();
            showAdmin();
        }


        public void showAdmin()
        {
            var c = new DormEntities2();
            var q = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q.ToList();

            //SolidColorBrush b = new SolidColorBrush();
            //b.Color = Color.FromArgb(0xFF, 0xFF, 0x0, 0x0);
            //gridList.Foreground = b;

        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            string account_ = AccountTextBox.Text;
            string password_ = PasswordTextBox.Text;
            if (account_ == "" || account_ == null || password_ == "" || password_ == null)
            {
                add_fail();
                return;
            }

            var c = new DormEntities2();
            var q = from t in c.AdminTable select t;
            int count = q.Count();
            AdminTable adminTable = new AdminTable
            {
                Id = count + 1,
                account = account_,
                password = password_

            };


            c.AdminTable.Add(adminTable);
            c.SaveChanges();

            showAdmin();
            add_ok();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            AccountTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        private void add_ok()
        {
            MessageBoxz.ShowInfo("添加管理员成功");
        }


        private void add_fail()
        {
            MessageBoxz.ShowError("账号和密码不能为空");
        }
    }
}
