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
    /// VisitorRegister.xaml 的交互逻辑
    /// </summary>
    public partial class VisitorRegister : Page
    {
        public VisitorRegister()
        {
            InitializeComponent();
        }

        public void showAdmin()
        {
            var c = new DormEntities2();
            var q = from t in c.GuestInfo select t;
            dataGrid.ItemsSource = q.ToList();
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            string _stuName = stuName.Text;
            int _stuDormNum = int.Parse(stuDormNum.Text);
            string _oName = oName.Text;
            string _oSex = oSex.Text;
            int _oID = int.Parse(oID.Text);
            string _oReason = oReason.Text;
            string _oVisitTime = oVisitTime.Text;

            var c = new DormEntities2();
            var q = from t in c.GuestInfo select t;
            int count = q.Count();
            GuestInfo guestInfo = new GuestInfo
            {
                Id = count + 1,
                studentName = _stuName,
                dormNum = _stuDormNum,
                name = _oName,
                sex = _oSex,
                IDNumber = _oID,
                reason = _oReason,
                visitTime = _oVisitTime
            };


            c.GuestInfo.Add(guestInfo);
            c.SaveChanges();

            showAdmin();
            add_ok();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            stuName.Text = "";
            stuDormNum.Text = "";
            oName.Text = "";
            oSex.Text = "";
            oID.Text = "";
            oReason.Text = "";
            oVisitTime.Text = "";
        }

        private void add_ok()
        {
            MessageBoxz.ShowInfo("来访信息添加成功");
        }
    }
}
