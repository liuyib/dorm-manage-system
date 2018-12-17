using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        string path = "";
        OpenFileDialog ofd = new OpenFileDialog();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {

            ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "图片|*.jpg;*.png;*.gif;*.bmp;*.jpeg";
            string path = "";
            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
                img_photo.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string account_ = AccountTextBox.Text;
            string password_ = PasswordTextBox.Text;
            string sex_ = sex.Text;
            string telphone_ = telphone.Text;
            string idCard_ = idcard.Text;
            if (account_ == "" || account_ == null || password_ == "" || password_ == null)
            {
                fill_fail();
                return;
            }

            var c = new DormEntities();

            var query = from t in c.AdminTable where (t.account == account_ & t.password == password_) select t;

            if (query.Count() > 0)
            {




                MessageBoxz.ShowInfo("该用户名已经被注册");
            }
            else
            {
                //可以注册

                if (account_ == "" || account_ == null || password_ == "" || password_ == null || sex_ == "" || sex_ == null || telphone_ == "" || telphone_ == null || idCard_ == "" || idcard == null)
                {
                    MessageBoxz.ShowWarning("信息填写不完整！");
                    return;
                }

                if (telphone_.Length != 11)
                {
                    MessageBoxz.ShowWarning("手机号格式不正确！");
                    return;
                }
                if (idCard_.Length != 18)
                {
                    MessageBoxz.ShowWarning("身份证号格式不正确！");
                    return;

                }

                int count = c.AdminTable.Select(p => p.Id).ToList().Max();

                if (path == "")
                {
                    BitmapImage img = new BitmapImage(new Uri(@"\Resources\icoFiles\moren.png", UriKind.Relative));
                    byte[] bt = BitmapImageToByteArray(img);
                    AdminTable adminTable = new AdminTable
                    {
                        Id = count + 1,
                        account = account_,
                        password = password_,
                        sex = sex_,
                        telphone = telphone_,
                        idCard = idCard_,
                        photo = bt



                    };

                    c.AdminTable.Add(adminTable);
                    c.SaveChanges();
                    MessageBoxz.ShowInfo("恭喜您，注册新用户成功");
                    this.Close();

                }

                else
                {
                    System.IO.Stream mystream = ofd.OpenFile();
                    byte[] bt = new byte[mystream.Length];
                    mystream.Read(bt, 0, (int)mystream.Length);
                    AdminTable adminTable = new AdminTable
                    {
                        Id = count + 1,
                        account = account_,
                        password = password_,
                        sex = sex_,
                        telphone = telphone_,
                        idCard = idCard_,
                        photo = bt



                    };

                    c.AdminTable.Add(adminTable);
                    c.SaveChanges();
                    MessageBoxz.ShowInfo("恭喜您，注册新用户成功");
                    this.Close();
                }













            }
        }



        private void fill_fail()
        {
            MessageBoxz.ShowWarning("用户名和密码不能为空！");
        }

        private void login_fail()
        {
            MessageBoxz.ShowError("用户名或密码错误！");

        }

        public static byte[] BitmapImageToByteArray(BitmapImage bmp)
        {
            byte[] byteArray = null;

            try
            {
                Stream sMarket = bmp.StreamSource;

                if (sMarket != null && sMarket.Length > 0)
                {
                    //很重要，因为Position经常位于Stream的末尾，导致下面读取到的长度为0。     
                    sMarket.Position = 0;

                    using (BinaryReader br = new BinaryReader(sMarket))
                    {
                        byteArray = br.ReadBytes((int)sMarket.Length);
                    }
                }
            }
            catch (Exception)
            {

                //other exception handling     
            }

            return byteArray;
        }
    }
}
