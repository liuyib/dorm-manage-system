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

namespace WpfzDemos.Pages.StayManage
{
    /// <summary>
    /// QueryPeople.xaml 的交互逻辑
    /// </summary>
    public partial class QueryPeople : Page
    {
        public QueryPeople()
        {
            InitializeComponent();
            Loaded += delegate
            {
                using (var q = new Model1Container())
                {

                    var t = from z in q.StudentInfo select z;
                    gridList.ItemsSource = t.ToList();

                };
            };
            // 姓名查询
            btnBind.Click += delegate
            {
                using (var q = new Model1Container())
                {


                    var t = from z in q.StudentInfo
                            where z.name.ToString() == txtNumber1.Text
                            select z;
                    gridList.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        var t1 = from z1 in q.StudentInfo select z1;
                        gridList.ItemsSource = t1.ToList();

                        MessageBox.Show("没有找到信息，请确认姓名是否正确！");
                    }
                };
            };
            // 学号查询
            btnBind1.Click += delegate
            {
                using (var q = new Model1Container())
                {


                    var t = from z in q.StudentInfo
                            where z.studentNum.ToString() == txtNumber2.Text
                            select z;
                    gridList.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        var t1 = from z1 in q.StudentInfo select z1;
                        gridList.ItemsSource = t1.ToList();

                        MessageBox.Show("没有找到信息，请确认学号是否正确！");
                    }
                };
            };
            // 宿舍号
            btnBind2.Click += delegate
            {
                using (var q = new Model1Container())
                {
                    var t = from z in q.StudentInfo
                            where z.dormNum.ToString() == txtNumber3.Text
                            select z;
                    gridList.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        var t1 = from z1 in q.StudentInfo select z1;
                        gridList.ItemsSource = t1.ToList();

                        MessageBox.Show("没有找到信息，请确认宿舍号是否正确！");
                    }
                };
            };
        }
    }
}
