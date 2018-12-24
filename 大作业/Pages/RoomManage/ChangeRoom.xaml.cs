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
    /// ChangeRoom.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeRoom : Page
    {
        public ChangeRoom()
        {
            InitializeComponent();
            Loaded += delegate
            {
                using (var q = new DormEntities2())
                {

                    var t = from z in q.studentInfo select z;
                    gridList.ItemsSource = t.ToList();

                };
                BtnModify.Click += (s, e) =>
                {
                    using (var c = new DormEntities2())
                    {
                        int dormNum1 = Convert.ToInt32(t4.Text);
                        var linq1 = from z1 in c.studentInfo where (z1.dormNum == dormNum1) select z1;

                        foreach(var item in linq1)
                        {
                            item.bedNum = Convert.ToInt32(t1.Text);
                            item.boardNum = Convert.ToInt32(t2.Text);
                            item.boardMoney = Convert.ToInt32(t3.Text);
                        }

                        c.SaveChanges();
                        var t = from z in c.studentInfo select z;
                        gridList.ItemsSource = t.ToList();
                    }
                };

                gridList.SelectionChanged += (s, e) =>
                {
                    if (gridList.SelectedIndex == -1)
                    {
                        return;
                    }
                    DormInfo dormInfo1 = (DormInfo)gridList.SelectedItem;
                    t1.Text = dormInfo1.bedNum.ToString();
                    t2.Text = dormInfo1.boardNum.ToString();
                    t3.Text = dormInfo1.boardMoney.ToString();
                    t4.Text = dormInfo1.dormNum.ToString();
                };
            };
        }
    }
}
