using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Wpfz
{
    /// <summary>
    /// 公共附加属性(Attach Property)
    /// </summary>
    public static class Attach
    {
        // FocusBackground 获得焦点背景色
        /// <summary>
        /// 获得焦点背景色
        /// </summary>
        public static readonly DependencyProperty FocusBackgroundProperty = DependencyProperty.RegisterAttached(
            "FocusBackground", typeof(Brush), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static void SetFocusBackground(DependencyObject element, Brush value)
        {
            element.SetValue(FocusBackgroundProperty, value);
        }
        public static Brush GetFocusBackground(DependencyObject element)
        {
            return (Brush)element.GetValue(FocusBackgroundProperty);
        }
        //end--FocusBackground

        // FocusForeground 获得焦点前景色
        /// <summary>
        /// 获得焦点前景色
        /// </summary>
        public static readonly DependencyProperty FocusForegroundProperty = DependencyProperty.RegisterAttached(
            "FocusForeground", typeof(Brush), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static void SetFocusForeground(DependencyObject element, Brush value)
        {
            element.SetValue(FocusForegroundProperty, value);
        }
        public static Brush GetFocusForeground(DependencyObject element)
        {
            return (Brush)element.GetValue(FocusForegroundProperty);
        }
        //end--FocusForeground

        // MouseOverBackgroundProperty 鼠标悬停背景色
        /// <summary>
        /// 鼠标悬停背景色
        /// </summary>
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverBackground", typeof(Brush), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static void SetMouseOverBackground(DependencyObject element, Brush value)
        {
            element.SetValue(MouseOverBackgroundProperty, value);
        }
        public static Brush GetMouseOverBackground(DependencyObject element)
        {
            //mj：原语句 return (Brush)element.GetValue(FocusForegroundProperty);
            return (Brush)element.GetValue(MouseOverBackgroundProperty);
        }
        //end--MouseOverBackgroundProperty

        // MouseOverForegroundProperty 鼠标悬停前景色
        /// <summary>
        /// 鼠标悬停前景色
        /// </summary>
        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverForeground", typeof(Brush), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static void SetMouseOverForeground(DependencyObject element, Brush value)
        {
            element.SetValue(MouseOverForegroundProperty, value);
        }
        public static Brush GetMouseOverForeground(DependencyObject element)
        {
            return (Brush)element.GetValue(MouseOverForegroundProperty);
        }
        //end--MouseOverForegroundProperty

        // FocusBorderBrush 焦点边框色，输入控件
        /// <summary>
        /// 焦点边框色，输入控件
        /// </summary>
        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached(
            "FocusBorderBrush", typeof(Brush), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static void SetFocusBorderBrush(DependencyObject element, Brush value)
        {
            element.SetValue(FocusBorderBrushProperty, value);
        }
        public static Brush GetFocusBorderBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(FocusBorderBrushProperty);
        }
        //end--FocusBorderBrush

        // MouseOverBorderBrush 鼠标进入边框色，输入控件
        /// <summary>
        /// 鼠标进入边框色，输入控件
        /// </summary>
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.RegisterAttached(
                "MouseOverBorderBrush", typeof(Brush), typeof(Attach),
                new FrameworkPropertyMetadata(Brushes.Transparent,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));
        public static void SetMouseOverBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBorderBrushProperty, value);
        }

        /// <summary>
        /// 获取鼠标悬停时使用的绘制画笔（Brush）
        /// </summary>
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(RadioButton))]
        [AttachedPropertyBrowsableForType(typeof(DatePicker))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        [AttachedPropertyBrowsableForType(typeof(RichTextBox))]
        public static Brush GetMouseOverBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBorderBrushProperty);
        }
        //end--MouseOverBorderBrush

        // AttachContentProperty 附加组件模板
        /// <summary>
        /// 附加组件模板
        /// </summary>
        public static readonly DependencyProperty AttachContentProperty = DependencyProperty.RegisterAttached(
            "AttachContent", typeof(ControlTemplate), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static ControlTemplate GetAttachContent(DependencyObject d)
        {
            return (ControlTemplate)d.GetValue(AttachContentProperty);
        }
        public static void SetAttachContent(DependencyObject obj, ControlTemplate value)
        {
            obj.SetValue(AttachContentProperty, value);
        }
        //end--AttachContentProperty

        #region WatermarkProperty 水印
        /// <summary>
        /// 水印
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(Attach),
            new FrameworkPropertyMetadata(""));
        public static string GetWatermark(DependencyObject d)
        {
            return (string)d.GetValue(WatermarkProperty);
        }
        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
        #endregion

        #region IconzProperty 字体图标
        /// <summary>
        /// 字体图标
        /// </summary>
        public static readonly DependencyProperty IconzProperty = DependencyProperty.RegisterAttached(
            "Iconz", typeof(string), typeof(Attach),
            new FrameworkPropertyMetadata(""));
        public static string GetIconz(DependencyObject d)
        {
            return (string)d.GetValue(IconzProperty);
        }
        public static void SetIconz(DependencyObject obj, string value)
        {
            obj.SetValue(IconzProperty, value);
        }
        #endregion

        #region IconzSizeProperty 字体图标大小
        /// <summary>
        /// 字体图标
        /// </summary>
        public static readonly DependencyProperty IconzSizeProperty = DependencyProperty.RegisterAttached(
            "IconzSize", typeof(double), typeof(Attach),
            new FrameworkPropertyMetadata(12D));
        public static double GetIconzSize(DependencyObject d)
        {
            return (double)d.GetValue(IconzSizeProperty);
        }
        public static void SetIconzSize(DependencyObject obj, double value)
        {
            obj.SetValue(IconzSizeProperty, value);
        }
        #endregion

        #region IconzMarginProperty 字体图标边距
        /// <summary>
        /// 字体图标
        /// </summary>
        public static readonly DependencyProperty IconzMarginProperty = DependencyProperty.RegisterAttached(
            "IconzMargin", typeof(Thickness), typeof(Attach),
            new FrameworkPropertyMetadata(null));
        public static Thickness GetIconzMargin(DependencyObject d)
        {
            return (Thickness)d.GetValue(IconzMarginProperty);
        }
        public static void SetIconzMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(IconzMarginProperty, value);
        }
        #endregion

        #region AllowsAnimationProperty 启用旋转动画
        /// <summary>
        /// 启用旋转动画
        /// </summary>
        public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.RegisterAttached(
            "AllowsAnimation", typeof(bool), typeof(Attach),
            new FrameworkPropertyMetadata(false, AllowsAnimationChanged));
        public static bool GetAllowsAnimation(DependencyObject d)
        {
            return (bool)d.GetValue(AllowsAnimationProperty);
        }
        public static void SetAllowsAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowsAnimationProperty, value);
        }

        /// <summary>
        /// 旋转动画刻度
        /// </summary>
        private static DoubleAnimation RotateAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)));

        /// <summary>
        /// 绑定动画事件
        /// </summary>
        private static void AllowsAnimationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement uc)) return;
            if (uc.RenderTransformOrigin == new Point(0, 0))
            {
                uc.RenderTransformOrigin = new Point(0.5, 0.5);
                RotateTransform trans = new RotateTransform(0);
                uc.RenderTransform = trans;
            }
            var value = (bool)e.NewValue;
            if (value)
            {
                RotateAnimation.To = 180;
                uc.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, RotateAnimation);
            }
            else
            {
                RotateAnimation.To = 0;
                uc.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, RotateAnimation);
            }
        }
        #endregion

        #region CornerRadiusProperty Border圆角
        /// <summary>
        /// Border圆角
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius", typeof(CornerRadius), typeof(Attach),
            new FrameworkPropertyMetadata(null));

        public static CornerRadius GetCornerRadius(DependencyObject d)
        {
            return (CornerRadius)d.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
        #endregion

        #region LabelProperty TextBox的头部Label
        /// <summary>
        /// TextBox的头部Label
        /// </summary>
        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            "Label", typeof(string), typeof(Attach), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static string GetLabel(DependencyObject d)
        {
            return (string)d.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }
        #endregion

        #region LabelTemplateProperty TextBox的头部Label模板
        /// <summary>
        /// TextBox的头部Label模板
        /// </summary>
        public static readonly DependencyProperty LabelTemplateProperty = DependencyProperty.RegisterAttached(
            "LabelTemplate", typeof(ControlTemplate), typeof(Attach), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static ControlTemplate GetLabelTemplate(DependencyObject d)
        {
            return (ControlTemplate)d.GetValue(LabelTemplateProperty);
        }

        public static void SetLabelTemplate(DependencyObject obj, ControlTemplate value)
        {
            obj.SetValue(LabelTemplateProperty, value);
        }
        #endregion

        /************************************ RoutedUICommand Behavior enable **************************************/

        //#region IsMyClearTextButtonBehaviorEnabledProperty 清除输入框Text值按钮行为开关（设为ture时才会绑定事件）
        /// <summary>
        /// 清除输入框Text值按钮行为开关
        /// </summary>
        //public static readonly DependencyProperty IsClearTextButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached(
        //    "IsClearTextButtonBehaviorEnabled", typeof(bool), typeof(Attach),
        //    new FrameworkPropertyMetadata(false, IsClearTextButtonBehaviorEnabledChanged));

        //[AttachedPropertyBrowsableForType(typeof(TextBox))]
        //public static bool GetIsClearTextButtonBehaviorEnabled(DependencyObject d)
        //{
        //    return (bool)d.GetValue(IsClearTextButtonBehaviorEnabledProperty);
        //}

        //public static void SetIsClearTextButtonBehaviorEnabled(DependencyObject obj, bool value)
        //{
        //    obj.SetValue(IsClearTextButtonBehaviorEnabledProperty, value);
        //}

        /// <summary>
        /// 绑定清除Text操作的按钮事件
        /// </summary>
        //private static void IsClearTextButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var button = d as FButton;
        //    if (e.OldValue != e.NewValue && button != null)
        //    {
        //        button.CommandBindings.Add(MyClearTextCommandBinding);
        //    }
        //}
        //#endregion

        #region IsOpenFileButtonBehaviorEnabledProperty 选择文件命令行为开关
        /// <summary>
        /// 选择文件命令行为开关
        /// </summary>
        public static readonly DependencyProperty IsOpenFileButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached(
            "IsOpenFileButtonBehaviorEnabled", typeof(bool), typeof(Attach),
            new FrameworkPropertyMetadata(false, IsOpenFileButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsOpenFileButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenFileButtonBehaviorEnabledProperty);
        }

        public static void SetIsOpenFileButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOpenFileButtonBehaviorEnabledProperty, value);
        }

        private static void IsOpenFileButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Buttonz;
            if (e.OldValue != e.NewValue && button != null)
            {
                button.CommandBindings.Add(MyOpenFileCommandBinding);
            }
        }

        #endregion

        #region IsOpenFolderButtonBehaviorEnabledProperty 选择文件夹命令行为开关
        /// <summary>
        /// 选择文件夹命令行为开关
        /// </summary>
        public static readonly DependencyProperty IsOpenFolderButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached(
            "IsOpenFolderButtonBehaviorEnabled", typeof(bool), typeof(Attach),
            new FrameworkPropertyMetadata(false, IsOpenFolderButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsOpenFolderButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenFolderButtonBehaviorEnabledProperty);
        }

        public static void SetIsOpenFolderButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOpenFolderButtonBehaviorEnabledProperty, value);
        }

        private static void IsOpenFolderButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Buttonz;
            if (e.OldValue != e.NewValue && button != null)
            {
                button.CommandBindings.Add(MyOpenFolderCommandBinding);
            }
        }
        #endregion

        #region IsSaveFileButtonBehaviorEnabledProperty 选择文件保存路径及名称
        /// <summary>
        /// 选择文件保存路径及名称
        /// </summary>
        public static readonly DependencyProperty IsSaveFileButtonBehaviorEnabledProperty =
            DependencyProperty.RegisterAttached("IsSaveFileButtonBehaviorEnabled",
            typeof(bool), typeof(Attach),
            new FrameworkPropertyMetadata(false, IsSaveFileButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsSaveFileButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsSaveFileButtonBehaviorEnabledProperty);
        }

        public static void SetIsSaveFileButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSaveFileButtonBehaviorEnabledProperty, value);
        }

        private static void IsSaveFileButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Buttonz;
            if (e.OldValue != e.NewValue && button != null)
            {
                button.CommandBindings.Add(MySaveFileCommandBinding);
            }
        }

        #endregion

        /************************************ RoutedUICommand **************************************/

        #region MyClearTextCommand 清除输入框Text事件命令

        /// <summary>
        /// 清除输入框Text事件命令(需要使用IsClearTextButtonBehaviorEnabledChanged绑定命令)
        /// </summary>
        //public static RoutedUICommand MyClearTextCommand { get; private set; }

        /// <summary>
        /// ClearTextCommand绑定事件(清除输入框中的文本值)
        /// </summary>
        //private static readonly CommandBinding MyClearTextCommandBinding;
        #endregion

        #region MyOpenFileCommand 选择文件命令
        /// <summary>
        /// 选择文件命令(需要使用IsClearTextButtonBehaviorEnabledChanged绑定命令)
        /// </summary>
        public static RoutedUICommand MyOpenFileCommand { get; private set; }

        /// <summary>
        /// MyOpenFileCommand绑定事件
        /// </summary>
        private static readonly CommandBinding MyOpenFileCommandBinding;
        #endregion

        #region MyOpenFolderCommand 选择文件夹命令

        /// <summary>
        /// 选择文件夹命令
        /// </summary>
        public static RoutedUICommand MyOpenFolderCommand { get; private set; }

        /// <summary>
        /// MyOpenFolderCommand绑定事件
        /// </summary>
        private static readonly CommandBinding MyOpenFolderCommandBinding;

        #endregion

        #region MySaveFileCommand 选择文件保存路径及名称

        /// <summary>
        /// 选择文件保存路径及名称
        /// </summary>
        public static RoutedUICommand MySaveFileCommand { get; private set; }

        /// <summary>
        /// MySaveFileCommand绑定事件
        /// </summary>
        private static readonly CommandBinding MySaveFileCommandBinding;

        #endregion


        /// <summary>
        /// 静态构造函数
        /// </summary>
        static Attach()
        {
            //ClearTextCommand
            //MyClearTextCommand = new RoutedUICommand();
            //MyClearTextCommandBinding = new CommandBinding(MyClearTextCommand);
            //ClearButtonClick
            //MyClearTextCommandBinding.Executed += (s,e)=>
            //{
            //    var tbox = e.Parameter as FrameworkElement;
            //    if (tbox == null) return;
            //    if (tbox is TextBox)
            //    {
            //        ((TextBox)tbox).Clear();
            //    }
            //    if (tbox is PasswordBox)
            //    {
            //        ((PasswordBox)tbox).Clear();
            //    }
            //    if (tbox is ComboBox)
            //    {
            //        var cb = tbox as ComboBox;
            //        cb.SelectedItem = null;
            //        cb.Text = string.Empty;
            //    }
            //    if (tbox is ComboBoxMulti)
            //    {
            //        var cb = tbox as ComboBoxMulti;
            //        cb.SelectedItem = null;
            //        cb.UnselectAll();
            //        cb.Text = string.Empty;
            //    }
            //    if (tbox is DatePicker)
            //    {
            //        var dp = tbox as DatePicker;
            //        dp.SelectedDate = null;
            //        dp.Text = string.Empty;
            //    }
            //    tbox.Focus();
            //};

            //OpenFileCommand
            MyOpenFileCommand = new RoutedUICommand();
            MyOpenFileCommandBinding = new CommandBinding(MyOpenFileCommand);
            //OpenFileButtonClick
            MyOpenFileCommandBinding.Executed += (s,e)=>
            {
                var tbox = e.Parameter as FrameworkElement;
                var txt = tbox as TextBox;
                string filter = txt.Tag == null ? "所有文件(*.*)|*.*" : txt.Tag.ToString();
                if (filter.Contains(".bin"))
                {
                    filter += "|所有文件(*.*)|*.*";
                }
                if (txt == null) return;
                OpenFileDialog fd = new OpenFileDialog
                {
                    Title = "请选择文件",
                    //“图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*”
                    Filter = filter,
                    FileName = txt.Text.Trim()
                };
                if (fd.ShowDialog() == true)
                {
                    txt.Text = fd.FileName;
                }
                tbox.Focus();
            };

            //OpenFolderCommand
            MyOpenFolderCommand = new RoutedUICommand();
            MyOpenFolderCommandBinding = new CommandBinding(MyOpenFolderCommand);
            //OpenFolderButtonClick
            MyOpenFolderCommandBinding.Executed += (s, e) =>
            {
                var tbox = e.Parameter as FrameworkElement;
                if (!(tbox is TextBox txt)) return;
                OpenFileDialog ofd = new OpenFileDialog {
                    Title= "请选择文件路径",
                    InitialDirectory =txt.Text.Trim()
                };
                if (ofd.ShowDialog() == true)
                {
                    txt.Text = System.IO.Path.GetDirectoryName(ofd.FileName);
                }

                //winform.FolderBrowserDialog fd = new winform.FolderBrowserDialog
                //{
                //    Description = "请选择文件路径",
                //    SelectedPath = txt.Text.Trim()
                //};
                //if (fd.ShowDialog() == winform.DialogResult.OK)
                //{
                //    txt.Text = fd.SelectedPath;
                //}
                tbox.Focus();
            };

            MySaveFileCommand = new RoutedUICommand();
            MySaveFileCommandBinding = new CommandBinding(MySaveFileCommand);
            //SaveFileButtonClick
            MySaveFileCommandBinding.Executed += (s,e)=>
            {
                var tbox = e.Parameter as FrameworkElement;
                if (!(tbox is TextBox txt)) return;
                SaveFileDialog fd = new SaveFileDialog
                {
                    Title = "文件保存路径",
                    Filter = "所有文件(*.*)|*.*",
                    FileName = txt.Text.Trim()
                };
                if (fd.ShowDialog() == true)
                {
                    txt.Text = fd.FileName;
                }
                tbox.Focus();
            };
        }
    }

}
