using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 大作业
{
    /// <summary>
    /// Page_TreeView.xaml 的交互逻辑
    /// </summary>
    public partial class PageTreeView : Page
    {
        public PageTreeView()
        {
            InitializeComponent();
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            List<NodeX> ns = new List<NodeX>();
            string[] gs = new string[] { "基本信息", "及时通讯", "地理轨迹", "邮件", "网页痕迹", "网络购物" };
            string[] ps = new string[] { "QQ", "通讯录", "短信", "QQ邮箱", "QQ企业版", "WIFI-蓝牙信息" };
            string[] ios = new string[] {
                "\ue201", "\ue197", "\ue008", "\ue143", "\ue141", "\ue142"
            };
            var ioslen = ios.Length - 1;
            Random r = new Random();
            for (int i = 0; i < 30; i++)
            {
                var n1 = new NodeX();
                n1.Name = gs[r.Next(0, gs.Length - 1)];
                n1.FIcon = ios[r.Next(0, ioslen)];
                ns.Add(n1);
                int len = r.Next(6, 30);
                n1.Nodes = new List<NodeX>();
                for (int j = 0; j < 100; j++)
                {
                    var n2 = new NodeX();
                    n2.Name = ps[r.Next(0, 5)];
                    n2.FIcon = ios[r.Next(0, ioslen)];
                    n2.Nodes = new List<NodeX>();
                    n1.Nodes.Add(n2);
                    for (int a = 0; a < 30; a++)
                    {
                        var n3 = new NodeX();
                        n3.Name = ps[r.Next(0, 5)];
                        n3.FIcon = ios[r.Next(0, ioslen)];
                        n2.Nodes.Add(n3);
                    }
                }
            }
            this.tree1.ItemsSource = ns;
        }
    }

    public class NodeX
    {
        #region Property

        private string _Text;
        /// <summary>
        /// 显示的文本值
        /// </summary>
        public string Name
        {
            get { return this._Text; }
            set { this._Text = value; }
        }

        private bool? _Checked;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool? Checked
        {
            get { return this._Checked; }
            set { this._Checked = value;  }
        }

        private bool _IsExpand;
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpand
        {
            get { return this._IsExpand; }
            set { this._IsExpand = value; }
        }

        /// <summary>
        /// 节点图标：相对路径
        /// </summary>
        public string FIcon { get; set; }

        /// <summary>
        /// 子节点，默认null
        /// </summary>
        public IList<NodeX> Nodes { get; set; }

        /// <summary>
        /// 该节点数据项，默认null
        /// </summary>
        public virtual IList ItemSource { get; set; }


        /// <summary>
        /// 视图控件，只有当ViewType=UserControl时才有效
        /// </summary>
        public string ViewControl { get; set; }

        #endregion

        #region NodeX-构造函数（初始化）

        /// <summary>
        ///  NodeX-构造函数（初始化）
        /// </summary>
        public NodeX()
        {
            this.Name = string.Empty;
            this.FIcon = string.Empty;
            this.Checked = false;
        }

        #endregion
    }
}
