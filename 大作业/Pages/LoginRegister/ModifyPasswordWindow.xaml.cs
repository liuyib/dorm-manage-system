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

namespace WpfzDemos.Pages
{
    /// <summary>
    /// ModifyPasswordWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPasswordWindow : Window
    {
        string Account = "";
        public ModifyPasswordWindow(string name)
        {

            Account = name;
            InitializeComponent();
            // modify_show(Account);
        }

        public void modify_show(string name)
        {
           // MessageBox.Show(name);
            var c = new DormEntities2();
            var q = from t in c.AdminTable where (t.account == name) select t;
            string idCard =this.IdCardBox.Text ;
            string password_ = PasswordBox.Password;
            string password2_ = PasswordBox2.Password;
            if (password2_ != password_)
            {
                MessageBoxz.ShowWarning("两次密码不一致，");
                return;
            }
            if (q.Count() > 0)
            {
                //说明有该用户
                var q2 = from t in c.AdminTable where (t.account == name && t.idCard == idCard) select t;

               // MessageBox.Show(name+idCard);
                if(q2.Count()==1)
                q2.First<AdminTable>().password = password_;

                c.SaveChanges();
                MessageBoxz.ShowInfo("密码修改成功");
                this.Close();
              
            }
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            modify_show(Account);
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
