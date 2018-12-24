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

namespace WpfzDemos.Pages.RoomManage
{
    /// <summary>
    /// AddRoom.xaml 的交互逻辑
    /// </summary>
    public partial class AddRoom : Page
    {
        public AddRoom()
        {
            InitializeComponent();
            Loaded += delegate
            {
                using (var q = new DormEntities2())
                {
                    var t = from z in q.studentInfo select z;
                    gridList.ItemsSource = t.ToList();
                };

            };
            
            BtnAdd.Click += (s, e) =>
            {
                using (var c = new DormEntities2())
                {
                    var q = from t in c.studentInfo select t;
                    int count = q.Count();
                    DormInfo dromInfo = new DormInfo
                    {
                        Id = count + 1,
                        buildingNum = Convert.ToInt32(t1.Text),
                        dormNum = Convert.ToInt32(t2.Text),
                        bedNum = Convert.ToInt32(t3.Text),
                        boardNum = Convert.ToInt32(t4.Text),
                        boardMoney = Convert.ToInt32(t5.Text)
                    };
                    try
                    {
                        c.studentInfo.Add(dromInfo);
                        c.SaveChanges();
                        var t = from z in c.studentInfo select z;
                        gridList.ItemsSource = t.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.InnerException.Message, "出错了");
                    }
                }
            };

            gridList.SelectionChanged += (s, e) =>
            {
                if (gridList.SelectedIndex == -1)
                {
                    return;
                }
                DormInfo dromInfot1 = (DormInfo)gridList.SelectedItem;
                t1.Text = dromInfot1.buildingNum.ToString();
                t2.Text = dromInfot1.dormNum.ToString();
                t3.Text = dromInfot1.bedNum.ToString();
                t4.Text = dromInfot1.boardNum.ToString();
                t5.Text = dromInfot1.boardMoney.ToString();
            };
        }
    }
}
