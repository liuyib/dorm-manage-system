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
using System.Windows.Shapes;
using Wpfz;
using 大作业;

namespace WpfzDemos.Pages
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Release\") || dataDir.EndsWith(@"\bin\Debug\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            if (this.DialogResult == false)
            {
                App.Current.Shutdown();
            }
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            string account_ = AccountTextBox.Text;
            string password_ = PasswordTextBox.Password;
            if (account_ == "" || account_ == null || password_ == "" || password_ == null)
            {
                fill_fail();
                return;
            }

            var c = new DormEntities();
            var query = from t in c.AdminTable where (t.account == account_ & t.password == password_) select t  ;
            
            if (query.Count() > 0)
            {
                MainWindow mainWindow = new MainWindow(account_);
                
                this.Close();
                mainWindow.Show();
                //    c.SubmitChanges();
            }
            else
            {
                login_fail();
            }

        }

        private void fill_fail()
        {
            MessageBoxz.ShowInfo("用户名和密码不能为空！");
        }

        private void login_fail()
        {
            MessageBoxz.ShowError("用户名或密码错误！");
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            //Register register = new Register();
            //register.ShowsNavigationUI();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();

            //string account_ = AccountTextBox.Text;
            //string password_ = PasswordTextBox.Password;
            //if (account_ == "" || account_ == null || password_ == "" || password_ == null)
            //{
            //    fill_fail();
            //    return;
            //}

            //var c = new DormEntities();

            //var query = from t in c.AdminTable where (t.account == account_ & t.password == password_) select t;

            //if (query.Count() > 0)
            //{




            //    MessageBoxz.ShowInfo("该用户名已经被注册");
            //}
            //else
            //{
            //    //可以注册
                
            //    var q2 = from t in c.AdminTable select t;
            //    int count = q2.Count();
            //    AdminTable adminTable = new AdminTable
            //    {
            //        Id = count + 1,
            //        account = account_,
            //        password = password_

            //    };

               
            //    c.AdminTable.Add(adminTable);
            //    c.SaveChanges();


            //    MessageBoxz.ShowInfo("恭喜您，注册新用户成功");




               
            //}
        }
    }
}
