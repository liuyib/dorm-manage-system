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

namespace WpfzDemos.Pages.RoomManage
{
    /// <summary>
    /// QueryRoom.xaml 的交互逻辑
    /// </summary>
    public partial class QueryRoom : Page
    {
        public QueryRoom()
        {
            InitializeComponent();
            Loaded += delegate
            {
                using (var q = new Model1Container())
                {

                    var t = from z in q.DormInfo select z;
                    gridList.ItemsSource = t.ToList();

                };
            };
            btnBind.Click += delegate
            {
                using (var q = new Model1Container())
                {


                    var t = from z in q.DormInfo
                            where z.buildingNum.ToString() == txtNumber1.Text &&
                            z.dormNum.ToString() == txtNumber2.Text
                            select z;
                    gridList1.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        MessageBox.Show("请确认楼号房间号是否正确！");
                    }

                };
            };
            btnBind1.Click += delegate
            {
                using (var q = new Model1Container())
                {


                    var t = from z in q.DormInfo
                            where z.buildingNum.ToString() == txtNumber1.Text
                            select z;
                    gridList1.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        MessageBox.Show("请确认楼号房间号是否正确！");
                    }

                };
            };
            btnBind2.Click += delegate
            {
                using (var q = new Model1Container())
                {


                    var t = from z in q.DormInfo
                            where z.dormNum < 4
                            select z;
                    gridList1.ItemsSource = t.ToList();

                    if (t.Count() == 0)
                    {
                        MessageBox.Show("Error:Please Input Correct Data! 请确认楼号房间号是否正确！");
                    }

                };
            };
        }
    }
}
