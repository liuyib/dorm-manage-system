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
    /// InStay.xaml 的交互逻辑
    /// </summary>
    public partial class InStay : Page
    {
        public InStay()
        {
            InitializeComponent();
            showAdmin();
        }

        public void showAdmin()
        {
            var c = new Model1Container();
            var q = from t in c.StudentInfo select t;
            dataGrid.ItemsSource = q.ToList();
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            string _stuName = stuName.Text;
            string _stuSex = stuSex.Text;
            int _stuID = int.Parse(stuID.Text);
            string _stuDepart = stuDepart.Text;
            string _stuProfession = stuProfession.Text;
            int _stuPhone = int.Parse(stuPhone.Text);
            int _stuBuildingNum = int.Parse(stuBuildingNum.Text);
            int _stuDormNum = int.Parse(stuDormNum.Text);
            string _stuTime = stuTime.Text;
            int _stuYear = int.Parse(stuYear.Text);

            var c = new Model1Container();
            var q = from t in c.StudentInfo select t;
            int count = q.Count();
            StudentInfo StudentInfo = new StudentInfo
            {
                Id = count + 1,
                name = _stuName,
                sex = _stuSex,
                studentNum = _stuID,
                department = _stuDepart,
                profession = _stuProfession,
                phoneNum = _stuPhone,
                buildingNum = _stuBuildingNum,
                dormNum = _stuDormNum,
                boardTime = _stuTime,
                schoolYearSystem = _stuYear
            };


            c.StudentInfo.Add(StudentInfo);
            c.SaveChanges();

            showAdmin();
            add_ok();
        }

        private void Buttonz_Click_1(object sender, RoutedEventArgs e)
        {
            stuName.Text = "";
            stuSex.Text = "";
            stuID.Text = "";
            stuDepart.Text = "";
            stuProfession.Text = "";
            stuPhone.Text = "";
            stuBuildingNum.Text = "";
            stuDormNum.Text = "";
            stuTime.Text = "";
            stuYear.Text = "";
        }

        private void add_ok()
        {
            MessageBoxz.ShowInfo("学生信息添加成功");
        }


        //private void add_fail()
        //{
        //    MessageBoxz.ShowError("账号和密码不能为空");
        //}
    }
}
