using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpfz.Core;

namespace Wpfz
{
    /// <summary>
    /// MyMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxz : Windowz
    {
        /// <summary>
        /// 结果，用户点击确定Result=true;
        /// </summary>
        public bool Result { get; private set; }

        private static readonly Dictionary<string, Brush> _Brushes = new Dictionary<string, Brush>();

        public MessageBoxz(EnumNotifyType type, string msg)
        {
            InitializeComponent();
            this.TxtMessage.Text = msg;
            BtnCancel.Visibility = Visibility.Collapsed;
            this.SetForeground(type);
            switch (type)
            {
                case EnumNotifyType.Error:
                    this.txtIcon.Text = "\ue083";
                    break;
                case EnumNotifyType.Warning:
                    this.txtIcon.Text = "\ue209";
                    break;
                case EnumNotifyType.Info:
                    this.txtIcon.Text = "\ue209";
                    break;
                case EnumNotifyType.Question:
                    this.txtIcon.Text = "\ue085";
                    this.BtnCancel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SetForeground(EnumNotifyType type)
        {
            string key = type.ToString() + "Foreground_Colors";
            if (!_Brushes.ContainsKey(key))
            {
                var b = this.TryFindResource(key) as Brush;
                _Brushes.Add(key, b);
            }
            this.Foreground = _Brushes[key];
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Result = true;
            this.Close();
            e.Handled = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Result = false;
            this.Close();
            e.Handled = true;
        }

        /********************* public static method **************************/

        /// <summary>
        /// 提示错误消息（Title默认为“错误”）
        /// </summary>
        public static void ShowError(string msg, string title = "错误", Window owner = null)
        {
            Show(EnumNotifyType.Error, msg, title, owner);
        }

        /// <summary>
        /// 提示普通消息（Title默认为“提示信息”）
        /// </summary>
        public static void ShowInfo(string msg, string title = "提示信息", Window owner = null)
        {
            Show(EnumNotifyType.Info, msg, title, owner);
        }

        /// <summary>
        /// 提示警告消息（Title默认为“警告”）
        /// </summary>
        public static void ShowWarning(string msg, string title = "警告", Window owner = null)
        {
            Show(EnumNotifyType.Warning, msg, title, owner);
        }

        /// <summary>
        /// 提示询问消息（Title默认为“询问信息”）
        /// </summary>
        public static bool ShowQuestion(string msg, string title = "询问信息", Window owner = null)
        {
            return Show(EnumNotifyType.Question, msg, title, owner);
        }

        /// <summary>
        /// 显示提示消息框，owner指定所属父窗体，不指定则默认值为null。
        /// </summary>
        private static bool Show(EnumNotifyType type, string msg, Window owner = null)
        {
            var result = true;
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBoxz nb = new MessageBoxz(type, msg)
                {
                    Owner = owner ?? ControlHelper.GetTopWindow()
                };
                nb.ShowDialog();
                result = nb.Result;
            });
            return result;
        }

        /// <summary>
        /// 显示带标题栏标题的提示消息框。owner指定所属父窗体，不指定则默认值为null。
        /// </summary>
        private static bool Show(EnumNotifyType type, string msg, string title, Window owner = null)
        {
            var result = true;
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBoxz nb = new MessageBoxz(type, msg)
                {
                    Title = title,
                    Owner = owner ?? ControlHelper.GetTopWindow()
                };
                nb.ShowDialog();
                result = nb.Result;
            });
            return result;
        }

        /// <summary>
        /// 通知消息类型
        /// </summary>
        public enum EnumNotifyType
        {
            [Description("错误")]
            Error,
            [Description("警告")]
            Warning,
            [Description("提示信息")]
            Info,
            [Description("询问信息")]
            Question,
        }
    }
}
