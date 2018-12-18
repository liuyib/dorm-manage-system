using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpfz
{
    /// <summary>
    /// DataPager.xaml 的交互逻辑
    /// </summary>
    public partial class DataPager : UserControl, INotifyPropertyChanged
    {
        public DataPager()
        {
            InitializeComponent();
        }

        #region 依赖属性和事件
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(DataPager), new UIPropertyMetadata(20));



        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(int), typeof(DataPager), new UIPropertyMetadata(0));



        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(DataPager), new UIPropertyMetadata(1));



        public string PageSizeList
        {
            get { return (string)GetValue(PageSizeListProperty); }
            set { SetValue(PageSizeListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSizeList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeListProperty =
            DependencyProperty.Register("PageSizeList", typeof(string), typeof(DataPager), new UIPropertyMetadata("20,50,100,200,300", (s, e) => {
                DataPager dp = s as DataPager;
                if (dp.PageSizeItems == null) dp.PageSizeItems = new List<int>();
                else dp.PageSizeItems.Clear();
                dp.RaisePropertyChanged("PageSizeItems");
            }));

        public IEnumerable<object> ListItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ListItemsSourceProperty); }
            set { SetValue(ListItemsSourceProperty, value); }
        }

        /// <summary>
        /// ItemsSource数据源
        /// </summary>
        public static readonly DependencyProperty ListItemsSourceProperty =
            DependencyProperty.Register("ListItemsSource", typeof(IEnumerable<object>), typeof(DataPager), new UIPropertyMetadata(null));




        /// <summary>
        /// ItemsSource数据源
        /// </summary>
        public DataView DataViewItemsSource
        {
            get { return (DataView)GetValue(DataViewItemsSourceProperty); }
            set { SetValue(DataViewItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty DataViewItemsSourceProperty =
            DependencyProperty.Register(" DataViewItemsSource", typeof(DataView), typeof(DataPager), new UIPropertyMetadata(null));


        public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent("PageChanged", RoutingStrategy.Bubble, typeof(PageChangedEventHandler), typeof(DataPager));
        /// <summary>
        /// 分页更改事件
        /// </summary>
        public event PageChangedEventHandler PageChanged
        {
            add
            {
                AddHandler(PageChangedEvent, value);
            }
            remove
            {
                RemoveHandler(PageChangedEvent, value);
            }
        }
        #endregion


        #region 通知属性
        private List<int> _pageSizeItems;
        /// <summary>
        /// 显示每页记录数集合
        /// </summary>
        public List<int> PageSizeItems
        {
            get
            {
                if (_pageSizeItems == null)
                {
                    _pageSizeItems = new List<int>();
                }
                if (PageSizeList != null)
                {
                    List<string> strs = PageSizeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    _pageSizeItems.Clear();
                    strs.ForEach(c => {
                        _pageSizeItems.Add(Convert.ToInt32(c));
                    });
                }
                return _pageSizeItems;
            }
            set
            {
                if (_pageSizeItems != value)
                {
                    _pageSizeItems = value;
                    RaisePropertyChanged("PageSizeItems");
                }
            }
        }

        private int _pageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                if (_pageCount != value)
                {
                    _pageCount = value;
                    RaisePropertyChanged("PageCount");
                }
            }
        }

        private int _start;
        /// <summary>
        /// 开始记录数
        /// </summary>
        public int Start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    RaisePropertyChanged("Start");
                }
            }
        }

        private int _end;
        /// <summary>
        /// 结束记录数
        /// </summary>
        public int End
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    RaisePropertyChanged("End");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 字段、属性、委托
        public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs args);
        private PageChangedEventArgs pageChangedEventArgs;
        #endregion



        #region 引发分页更改事件
        /// <summary>
        /// 引发分页更改事件
        /// </summary>
        private void RaisePageChanged()
        {
            if (pageChangedEventArgs == null)
            {
                pageChangedEventArgs = new PageChangedEventArgs(PageChangedEvent, PageSize, PageIndex);
            }
            else
            {
                pageChangedEventArgs.PageSize = this.PageSize;
                pageChangedEventArgs.PageIndex = this.PageIndex;
            }
            RaiseEvent(pageChangedEventArgs);
            //calc start、end
            if (ListItemsSource == null && DataViewItemsSource == null)
            {
                Start = End = PageCount = Total = 0;
            }
            if (ListItemsSource != null)
            {
                int curCount = ListItemsSource.Count();
                Start = (PageIndex - 1) * PageSize + 1;
                End = Start + curCount - 1;

                if (Total % PageSize != 0)
                {
                    PageCount = Total / PageSize + 1;
                }
                else
                {
                    PageCount = Total / PageSize;
                }
            }
            if (DataViewItemsSource != null)
            {
                int curCount = DataViewItemsSource.Count;
                Start = (PageIndex - 1) * PageSize + 1;
                End = Start + curCount - 1;

                if (Total % PageSize != 0)
                {
                    PageCount = Total / PageSize + 1;
                }
                else
                {
                    PageCount = Total / PageSize;
                }
            }

            //调整图片的显示
            btnFirst.IsEnabled = btnPrev.IsEnabled = (PageIndex != 1);
            btnNext.IsEnabled = btnLast.IsEnabled = (PageIndex != PageCount);
        }
        #endregion

        #region 分页操作事件
        void DataPager_Loaded(object sender, RoutedEventArgs e)
        {
            RaisePageChanged();
        }

        private void CbpPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                PageSize = (int)cboPageSize.SelectedItem;
                RaisePageChanged();
            }
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 1;
            RaisePageChanged();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex > 1)
            {
                --PageIndex;
            }
            RaisePageChanged();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Total % PageSize != 0)
            {
                PageCount = Total / PageSize + 1;
            }
            else
            {
                PageCount = Total / PageSize;
            }

            if (PageIndex < PageCount)
            {
                ++PageIndex;
            }
            RaisePageChanged();
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            if (Total % PageSize != 0)
            {
                PageCount = Total / PageSize + 1;
            }
            else
            {
                PageCount = Total / PageSize;
            }
            PageIndex = PageCount;
            RaisePageChanged();
        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RaisePageChanged();
        }

        private void TbPageIndex_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TbPageIndex_LostFocus(sender, null);
            }
        }

        private void TbPageIndex_LostFocus(object sender, RoutedEventArgs e)
        {
            int pIndex = 0;
            try
            {
                pIndex = Convert.ToInt32(tbPageIndex.Text);
            }
            catch { pIndex = 1; }

            if (pIndex < 1) PageIndex = 1;
            else if (pIndex > PageCount) PageIndex = PageCount;
            else PageIndex = pIndex;

            RaisePageChanged();
        }
        #endregion

        /// <summary>
        /// 刷新分页控件方法
        /// </summary>
        public void Refresh()
        {
            PageIndex = 1;
            RaisePageChanged();
        }
    }

    /// <summary>
    /// 分页更改参数
    /// </summary>
    public class PageChangedEventArgs : RoutedEventArgs
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public PageChangedEventArgs(RoutedEvent routeEvent, int pageSize, int pageIndex)
            : base(routeEvent)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
        }
    }
}
