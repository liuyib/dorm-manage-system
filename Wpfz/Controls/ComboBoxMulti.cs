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

namespace Wpfz
{
    [TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
    public class ComboBoxMulti : ComboBox
    {
        static ComboBoxMulti()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ComboBoxMulti),
                new FrameworkPropertyMetadata(typeof(ComboBoxMulti)));
        }

        public ComboBoxMulti()
        {
            this.Style = this.FindResource("ComboBoxMultiDefaultStyle") as Style;
        }

        /// <summary>
        /// 获取选择项集合
        /// </summary>
        public IList SelectedItems
        {
            get { return this._ListBox.SelectedItems; }
        }

        /// <summary>
        /// 设置或获取选择项
        /// </summary>
        public new int SelectedIndex
        {
            get { return this._ListBox.SelectedIndex; }
            set { this._ListBox.SelectedIndex = value; }
        }

        private ListBox _ListBox = new ListBox();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._ListBox = Template.FindName("PART_ListBox", this) as ListBox;
            this._ListBox.SelectionChanged += _ListBox_SelectionChanged;
        }

        void _ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.SelectedItems)
            {
                sb.Append(item.ToString()).Append(";");
            }
            this.Text = sb.ToString().TrimEnd(';');
        }


        public void SelectAll()
        {
            this._ListBox.SelectAll();

        }

        public void UnselectAll()
        {
            this._ListBox.UnselectAll();
        }
    }
}
