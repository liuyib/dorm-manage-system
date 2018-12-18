using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
namespace Wpfz
{
    public enum DateTimePickerFormat
    {
        /// <summary>格式：yyyy-MM-dd HH:mm:ss，例如：2018-02-09 13:05:04</summary>
        DateAndTime,
        /// <summary>格式：yyyy年M月d日(dddd) H:mm:ss tt，例如：2018年2月9日(星期四) 8:05:04 上午</summary>
        DateAndTimeLong,
        /// <summary>格式：yyyy-MM-ddd(dddd) </summary>
        DateAndTimeLongNew,
        /// <summary>格式：yyyy-MM-dd，例如：2018-01-01</summary>
        DateOnly,
        /// <summary>格式：yyyy-MM，例如：2018-09</summary>
        YearMonthOnly,
        /// <summary>格式：HH:mm:ss，例如：13:05:04</summary>
        TimeOnly,
        /// <summary>自定义格式</summary>
        Custom
    }
    [System.ComponentModel.DefaultBindingProperty("Value")]
    public class DateTimePicker : Control
    {
        private CheckBox _checkBox;
        internal TextBox _textBox;
        private TextBlock _textBlock;
        private Popup _popUp;
        private Calendar _calendar;
        private BlockManager _blockManager;
        private readonly string _defaultFormat = "yyyy-MM-dd";

        [Category("DateTimePicker")]
        public bool ShowCheckBox
        {
            get { return this._checkBox.Visibility == Visibility.Visible ? true : false; }
            set
            {
                if (value) this._checkBox.Visibility = Visibility.Visible;
                else
                {
                    this._checkBox.Visibility = Visibility.Collapsed;
                    this.Checked = true;
                }
            }
        }

        [Category("DateTimePicker")]
        public bool ShowDropDown
        {
            get { return this._textBlock.Visibility == Visibility.Visible ? true : false; }
            set
            {
                if (value) this._textBlock.Visibility = Visibility.Visible;
                else this._textBlock.Visibility = Visibility.Collapsed;
            }
        }

        [Category("DateTimePicker")]
        public bool Checked
        {
            get { return this._checkBox.IsChecked ?? false; }
            set { this._checkBox.IsChecked = value; }
        }

        [Category("DateTimePicker")]
        private string FormatString
        {
            get
            {
                switch (this.Format)
                {
                    case DateTimePickerFormat.DateAndTime: return "yyyy-MM-dd HH:mm:ss";
                    case DateTimePickerFormat.DateAndTimeLong: return "yyyy年M月d日(dddd) H:mm:ss tt";
                    case DateTimePickerFormat.DateAndTimeLongNew: return "yyyy-MM-dd(dddd)";
                    case DateTimePickerFormat.DateOnly: return "yyyy-MM-dd";
                    case DateTimePickerFormat.YearMonthOnly: return "yyyy-MM";
                    case DateTimePickerFormat.TimeOnly: return "HH:mm:ss";
                    case DateTimePickerFormat.Custom:
                        if (string.IsNullOrEmpty(this.CustomFormat)) return this._defaultFormat;
                        else return this.CustomFormat;
                    default: return this._defaultFormat;
                }
            }
        }

        private string _customFormat;
        [Category("DateTimePicker")]
        public string CustomFormat
        {
            get { return this._customFormat; }
            set
            {
                this._customFormat = value;
                this._blockManager = new BlockManager(this, this.FormatString);
            }
        }

        private DateTimePickerFormat _format;
        [Category("DateTimePicker")]
        public DateTimePickerFormat Format
        {
            get { return this._format; }
            set
            {
                this._format = value;
                this._blockManager = new BlockManager(this, this.FormatString);
            }
        }

        [Category("DateTimePicker")]
        public DateTime? Value
        {
            get
            {
                if (!this.Checked) return null;
                return (DateTime?)GetValue(ValueProperty);
            }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(DateTime?),
                typeof(DateTimePicker),
                new FrameworkPropertyMetadata(DateTime.Now,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(DateTimePicker.OnValueChanged),
                    new CoerceValueCallback(DateTimePicker.CoerceValue),
                    true,
                    System.Windows.Data.UpdateSourceTrigger.PropertyChanged));

        public static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DateTimePicker)._blockManager.Render();
        }

        static object CoerceValue(DependencyObject d, object value)
        {
            return value;
        }

        internal DateTime InternalValue
        {
            get
            {
                DateTime? value = this.Value;
                if (value.HasValue) return value.Value;
                return DateTime.MinValue;
            }
        }

        public DateTimePicker()
        {
            this.Initializ();
            this._blockManager = new BlockManager(this, this.FormatString);
        }

        private void Initializ()
        {
            this.Template = this.GetTemplate();
            this.ApplyTemplate();
            this._checkBox = (CheckBox)this.Template.FindName("checkBox", this);
            this._textBox = (TextBox)this.Template.FindName("textBox", this);
            this._textBlock = (TextBlock)this.Template.FindName("textBlock", this);
            this._calendar = new Calendar();
            this._popUp = new Popup
            {
                PlacementTarget = this._textBox,
                Placement = PlacementMode.Bottom,
                Child = this._calendar
            };

            this._checkBox.Visibility = Visibility.Collapsed;
            this.Checked = true;
            this.FontSize = 13;
            this.FontFamily = new FontFamily("Microsoft YaHei");

            //this._checkBox.Checked += new RoutedEventHandler(_checkBox_Checked);
            this._checkBox.Checked += delegate { this._textBox.IsEnabled = this.Checked; };

            //this._checkBox.Unchecked += new RoutedEventHandler(_checkBox_Checked);
            this._checkBox.Unchecked += delegate { this._textBox.IsEnabled = this.Checked; };

            //this.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(dateTimePicker_MouseWheel);
            this.MouseWheel += (s, e) => { this._blockManager.Change(((e.Delta < 0) ? -1 : 1), true); };

            this.Focusable = false;
            this._textBox.Cursor = System.Windows.Input.Cursors.Arrow;
            this._textBox.AllowDrop = false;

            //this._textBox.GotFocus += new System.Windows.RoutedEventHandler(_textBox_GotFocus);
            this._textBox.GotFocus += delegate { this._blockManager.ReSelect(); };

            //this._textBox.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(_textBox_PreviewMouseUp);
            this._textBox.PreviewMouseUp += delegate { this._blockManager.ReSelect(); };

            //this._textBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(_textBox_PreviewKeyDown);
            this._textBox.PreviewKeyDown += (s, e) =>
            {
                byte b = (byte)e.Key;
                if (e.Key == System.Windows.Input.Key.Left) this._blockManager.Left();
                else if (e.Key == System.Windows.Input.Key.Right) this._blockManager.Right();
                else if (e.Key == System.Windows.Input.Key.Up) this._blockManager.Change(1, true);
                else if (e.Key == System.Windows.Input.Key.Down) this._blockManager.Change(-1, true);
                if (b >= 34 && b <= 43) this._blockManager.ChangeValue(b - 34);
                if (!(e.Key == System.Windows.Input.Key.Tab)) e.Handled = true;
            };

            this._textBox.ContextMenu = null;
            this._textBox.IsEnabled = this.Checked;
            this._textBox.IsReadOnly = true;
            this._textBox.IsReadOnlyCaretVisible = false;

            //this._textBlock.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(_textBlock_MouseLeftButtonDown);
            this._textBlock.MouseLeftButtonDown += delegate { this._popUp.IsOpen = !(this._popUp.IsOpen); };

            //this._calendar.SelectedDatesChanged += new EventHandler<SelectionChangedEventArgs>(calendar_SelectedDatesChanged);
            this._calendar.SelectedDatesChanged += (sender, e) =>
            {
                this.Checked = true;
                ((sender as Calendar).Parent as Popup).IsOpen = false;
                DateTime selectedDate = (DateTime)e.AddedItems[0];
                this.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, this.InternalValue.Hour, this.InternalValue.Minute, this.InternalValue.Second);
                this._blockManager.Render();
            };
        }

        //void _textBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    this._popUp.IsOpen = !(this._popUp.IsOpen);
        //}

        //void _checkBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    this._textBox.IsEnabled = this.Checked;
        //}

        //void dateTimePicker_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        //{
        //    this._blockManager.Change(((e.Delta < 0) ? -1 : 1), true);
        //}

        //void _textBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    this._blockManager.ReSelect();
        //}

        //void _textBox_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    this._blockManager.ReSelect();
        //}

        //void _textBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    byte b = (byte)e.Key;
        //    if (e.Key == System.Windows.Input.Key.Left) this._blockManager.Left();
        //    else if (e.Key == System.Windows.Input.Key.Right) this._blockManager.Right();
        //    else if (e.Key == System.Windows.Input.Key.Up) this._blockManager.Change(1, true);
        //    else if (e.Key == System.Windows.Input.Key.Down) this._blockManager.Change(-1, true);
        //    if (b >= 34 && b <= 43) this._blockManager.ChangeValue(b - 34);
        //    if (!(e.Key == System.Windows.Input.Key.Tab)) e.Handled = true;
        //}

        //void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    this.Checked = true;
        //    ((sender as Calendar).Parent as Popup).IsOpen = false;
        //    DateTime selectedDate = (DateTime)e.AddedItems[0];
        //    this.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, this.InternalValue.Hour, this.InternalValue.Minute, this.InternalValue.Second);
        //    this._blockManager.Render();
        //}
 
        private ControlTemplate GetTemplate()
        {
            return (ControlTemplate)XamlReader.Parse(@"
<ControlTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                 xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
    <Border BorderBrush=""Black"" BorderThickness=""1"" CornerRadius=""1"">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width=""Auto""/>
                <ColumnDefinition Width=""*""/>
                <ColumnDefinition Width=""Auto""/>
             </Grid.ColumnDefinitions>
             <CheckBox Grid.Column=""0"" x:Name=""checkBox"" VerticalAlignment=""Center""/>
             <TextBox Grid.Column=""1"" x:Name=""textBox""
                      Style=""{StaticResource TextBox_ShareEditableStyle}""
                      HorizontalAlignment=""Center""
                      SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""
                      FontFamily=""{TemplateBinding FontFamily}""
                      Foreground=""{TemplateBinding Foreground}""
                      FontSize=""{TemplateBinding FontSize}""/>
             <TextBlock Grid.Column=""2"" Name = ""textBlock"" Text=""▼"" VerticalAlignment=""Center""/>
        </Grid>
    </Border>
</ControlTemplate>");
        }

        public override string ToString()
        {
            return this.InternalValue.ToString();
        }
    }

    internal class BlockManager
    {
        internal DateTimePicker _dateTimePicker;
        private List<Block> _blocks;
        private string _format;
        private Block _selectedBlock;
        private int _selectedIndex;
        public event EventHandler NeglectProposed;
        private readonly string[] _supportedFormats = new string[] {
                "yyyy", "MMMM", "dddd",
                "yyy", "MMM", "ddd",
                "yy", "MM", "dd",
                "y", "M", "d",
                "HH", "H", "hh", "h",
                "mm", "m",
                "ss", "s",
                "tt", "t",
                "fff", "ff", "f",
                "K", "g"
        };

        public BlockManager(DateTimePicker dateTimePicker, string format)
        {
            this._dateTimePicker = dateTimePicker;
            this._format = format;
            this._dateTimePicker.LostFocus += new RoutedEventHandler(_dameer_LostFocus);
            this._blocks = new List<Block>();
            this.InitBlocks();
        }

        private void InitBlocks()
        {
            foreach (string f in this._supportedFormats)
            {
                this._blocks.AddRange(this.GetBlocks(f));
            }
            this._blocks = this._blocks.OrderBy((a) => a.Index).ToList();
            this._selectedBlock = this._blocks[0];
            this.Render();
        }

        internal void Render()
        {
            int accum = 0;
            StringBuilder sb = new StringBuilder(this._format);
            foreach (Block b in this._blocks)
            {
                b.Render(ref accum, sb);
            }
            this._dateTimePicker._textBox.Text = this._format = sb.ToString();
            this.Select(this._selectedBlock);
        }

        private List<Block> GetBlocks(string pattern)
        {
            List<Block> bCol = new List<Block>();
            int index = -1;
            while ((index = this._format.IndexOf(pattern, ++index)) > -1)
            {
                bCol.Add(new Block(this, pattern, index));
            }
            this._format = this._format.Replace(pattern, (0).ToString().PadRight(pattern.Length, '0'));
            return bCol;
        }

        internal void ChangeValue(int p)
        {
            this._selectedBlock.Proposed = p;
            this.Change(this._selectedBlock.Proposed, false);
        }

        internal void Change(int value, bool upDown)
        {
            this._dateTimePicker.Value = this._selectedBlock.Change(this._dateTimePicker.InternalValue, value, upDown);
            if (upDown) this.OnNeglectProposed();
            this.Render();
        }

        internal void Right()
        {
            if (this._selectedIndex + 1 < this._blocks.Count) this.Select(this._selectedIndex + 1);
        }

        internal void Left()
        {
            if (this._selectedIndex > 0) this.Select(this._selectedIndex - 1);
        }

        private void _dameer_LostFocus(object sender, RoutedEventArgs e)
        {
            this.OnNeglectProposed();
        }

        protected virtual void OnNeglectProposed()
        {
            //EventHandler temp = this.NeglectProposed;
            //if (temp != null)
            //{
            //    temp(this, EventArgs.Empty);
            //}
            this.NeglectProposed?.Invoke(this, EventArgs.Empty);
        }

        internal void ReSelect()
        {
            foreach (Block b in this._blocks)
            {
                if ((b.Index <= this._dateTimePicker._textBox.SelectionStart) && ((b.Index + b.Length) >= this._dateTimePicker._textBox.SelectionStart))
                {
                    this.Select(b);
                    return;
                }
            }
            Block bb = this._blocks.Where((a) => a.Index < this._dateTimePicker._textBox.SelectionStart).LastOrDefault();
            if (bb == null) this.Select(0);
            else this.Select(bb);
        }

        private void Select(int blockIndex)
        {
            if (this._blocks.Count > blockIndex) this.Select(this._blocks[blockIndex]);
        }

        private void Select(Block block)
        {
            if (!(this._selectedBlock == block)) this.OnNeglectProposed();
            this._selectedIndex = this._blocks.IndexOf(block);
            this._selectedBlock = block;
            this._dateTimePicker._textBox.Select(block.Index, block.Length);
        }
    }

    internal class Block
    {
        private readonly BlockManager _blockManager;
        internal string Pattern { get; set; }
        internal int Index { get; set; }
        private int _length;
        internal int Length
        {
            get { return this._length; }
            set { this._length = value; }
        }
        private readonly int _maxLength;
        private string _proposed;
        internal int Proposed
        {
            get
            {
                string p = this._proposed;
                return int.Parse(p.PadLeft(this.Length, '0'));
            }
            set
            {
                if (!(this._proposed == null) && this._proposed.Length >= this._maxLength)
                    this._proposed = value.ToString();
                else
                    this._proposed = string.Format("{0}{1}", this._proposed, value);
            }
        }

        public Block(BlockManager blockManager, string pattern, int index)
        {
            this._blockManager = blockManager;

            //this._blockManager.NeglectProposed += new EventHandler(_blockManager_NeglectProposed);
            this._blockManager.NeglectProposed += delegate { this._proposed = null; };

            this.Pattern = pattern;
            this.Index = index;
            this.Length = this.Pattern.Length;
            this._maxLength = this.GetMaxLength(this.Pattern);
        }

        private int GetMaxLength(string p)
        {
            switch (p)
            {
                case "y":
                case "M":
                case "d":
                case "h":
                case "m":
                case "s":
                case "H":
                    return 2;
                case "yyy":
                    return 4;
                default:
                    return p.Length;
            }
        }

        //private void _blockManager_NeglectProposed(object sender, EventArgs e)
        //{
        //    this._proposed = null;
        //}

        internal DateTime Change(DateTime dateTime, int value, bool upDown)
        {
            if (!upDown && !this.CanChange()) return dateTime;
            int y, m, d, h, n, s;
            y = dateTime.Year;
            m = dateTime.Month;
            d = dateTime.Day;
            h = dateTime.Hour;
            n = dateTime.Minute;
            s = dateTime.Second;

            if (this.Pattern.Contains("y")) y = ((upDown) ? dateTime.Year + value : value);
            else if (this.Pattern.Contains("M")) m = ((upDown) ? dateTime.Month + value : value);
            else if (this.Pattern.Contains("d")) d = ((upDown) ? dateTime.Day + value : value);
            else if (this.Pattern.Contains("h") || this.Pattern.Contains("H"))
            {
                h = ((upDown) ? dateTime.Hour + value : value);
            }
            else if (this.Pattern.Contains("m")) n = ((upDown) ? dateTime.Minute + value : value);
            else if (this.Pattern.Contains("s")) s = ((upDown) ? dateTime.Second + value : value);
            else if (this.Pattern.Contains("t")) h = ((h < 12) ? (h + 12) : (h - 12));

            if (y > 9999) y = 1;
            if (y < 1) y = 9999;
            if (m > 12) m = 1;
            if (m < 1) m = 12;
            if (d > DateTime.DaysInMonth(y, m)) d = 1;
            if (d < 1) d = DateTime.DaysInMonth(y, m);
            if (h > 23) h = 0;
            if (h < 0) h = 23;
            if (n > 59) n = 0;
            if (n < 0) n = 59;
            if (s > 59) s = 0;
            if (s < 0) s = 59;

            return new DateTime(y, m, d, h, n, s);
        }

        private bool CanChange()
        {
            switch (this.Pattern)
            {
                case "MMMM":
                case "dddd":
                case "MMM":
                case "ddd":
                case "g":
                    return false;
                default:
                    return true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Pattern, this.Index);
        }

        internal void Render(ref int accum, StringBuilder sb)
        {
            this.Index += accum;
            string f = this._blockManager._dateTimePicker.InternalValue.ToString(this.Pattern + ",").TrimEnd(',');
            sb.Remove(this.Index, this.Length);
            sb.Insert(this.Index, f);
            accum += f.Length - this.Length;
            this.Length = f.Length;
        }
    }
}
