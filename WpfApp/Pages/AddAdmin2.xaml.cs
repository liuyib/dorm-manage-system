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

namespace WpfzDemos.Pages
{
    /// <summary>
    /// AddAdmin2.xaml 的交互逻辑
    /// </summary>
    public partial class AddAdmin2 : Page
    {
        public AddAdmin2()
        {

            InitializeComponent();
            showAdmin();
        }


        public void showAdmin()
        {
            var c = new DormEntities();

            var q = from t in c.AdminTable select t;
            dataGrid.ItemsSource = q.ToList();

            //SolidColorBrush b = new SolidColorBrush();
            //b.Color = Color.FromArgb(0xFF, 0xFF, 0x0, 0x0);
            //gridList.Foreground = b;

        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            //string account_=
        }
    }
}
