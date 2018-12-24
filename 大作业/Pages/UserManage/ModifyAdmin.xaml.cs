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

namespace WpfzDemos.Pages
{
    /// <summary>
    /// ModifyAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyAdmin : Page
    {
        public ModifyAdmin()
        {
            InitializeComponent();

            showAdmin();
        }


        public void showAdmin()
        {
            var c = new DormEntities();

            var q = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q.ToList();
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = (dataGrid.SelectedItem as AdminTable).Id;
                string account__ = (dataGrid.SelectedItem as AdminTable).account;
                string password__ = (dataGrid.SelectedItem as AdminTable).password;

                // MessageBox.Show(account__+"  "+password__);
                string account_ = AccountTextBox.Text;
                string password_ = PasswordTextBox.Text;
                if (account_ == "" || account_ == null || password_ == "" || password_ == null)
                {
                    modify_fail();
                    return;
                }

                var c = new DormEntities();
                var query = from t in c.AdminTable where (t.account == account__ && t.password == password__) select t;

                int temp = query.Count();

                if (query.Count() > 0)
                {
                    query.First<AdminTable>().account = account_;
                    query.First<AdminTable>().password = password_;


                    c.SaveChanges();
                    modify_ok();
                }


                var q = from t in c.AdminTable select t;
                dataGrid.ItemsSource = q.ToList();
            }
            catch (Exception)
            {
                MessageBoxz.ShowWarning("请选择一个管理员");
                //throw;
            }
          

            //var c = new DormEntities();
            //var q = from t in c.AdminTable select t;
            //int count = q.Count();
            //AdminTable adminTable = new AdminTable
            //{
            //    Id = count + 1,
            //    account = account_,
            //    password = password_

            //};

            //c.AdminTable.Add(adminTable);
            //c.SaveChanges();

            // showAdmin();
            //modify_ok();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            AccountTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        private void modify_ok()
        {
            MessageBoxz.ShowInfo("修改管理员成功");
        }


        private void modify_fail()
        {
            MessageBoxz.ShowError("修改失败，账号或密码不能为空");
        }

  

      
    }
}
