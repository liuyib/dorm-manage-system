using System;
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
using Wpfz;

namespace 大作业
{
    /// <summary>
    /// Page_Button.xaml 的交互逻辑
    /// </summary>
    public partial class PageButton : Page
    {
        public PageButton()
        {
            InitializeComponent();

            string[] s = Enum.GetNames(typeof(IconzEnum));
            txtTite.Text = $"Iconz图标及编码（共{s.Length}个）";
            for (int i = 0; i < s.Length; i++)
            {
                string s1 = s[i].Substring(0, 4);
                string s2 = s[i];
                int c = int.Parse(s1, System.Globalization.NumberStyles.AllowHexSpecifier);
                Buttonz btn = new Buttonz()
                {
                    Iconz = $"{(char)c}",
                    IconzSize = 20,
                    Content = s2,
                    Width = 200,
                    Padding = new Thickness(5, 0, 0, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(2, 2, 2, 2)
                };
                WrapPanel1.Children.Add(btn);
            }
        }
     }
}
