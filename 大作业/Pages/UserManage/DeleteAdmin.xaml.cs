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
    /// DeleteAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteAdmin : Page
    {
        public DeleteAdmin()
        {
            InitializeComponent();
            showAdmin();
        }
        public void showAdmin()
        {
            var c = new Model1Container();

            var q = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q.ToList();


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deCheck_Checked(object sender, RoutedEventArgs e)
        {

            string account_ = accountBox.Text;
            var c = new Model1Container();
            var q = (from t in c.AdminTable where t.account == account_ select t).First<AdminTable>() ;
          c.AdminTable.Remove(q);
            c.SaveChanges();
            deleOK(account_);
          var q2 = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q2.ToList();
        }

       

        private void deleOK(string account)
        {
            MessageBoxz.ShowInfo("已成功删除管理员 "+account);
        }
    }
}
