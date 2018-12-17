using System;
using System.Collections.Generic;
using System.IO;
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
    /// Page_ImageViewer.xaml 的交互逻辑
    /// </summary>
    public partial class PageImageViewer : Page
    {
        public PageImageViewer()
        {
            InitializeComponent();

            ImgViewer.ItemsSource = null;

            //获取当前项目可执行文件的路径
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            TxtFolder.Text = appPath.Replace(@"\bin\Debug", @"\Resources\Pictures");
        }

        private void Buttonz_Click(object sender, RoutedEventArgs e)
        {
            var path = this.TxtFolder.Text.Trim();
            string[] fs1 = null, fs2 = null;
            try
            {
                fs1 = System.IO.Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                fs2 = System.IO.Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
            }
            catch
            {
                MessageBoxz.ShowError("无法获取指定目录下的文件");
                return;
            }
            List<string> photoPaths = new List<string>();
            photoPaths.AddRange(fs1);
            photoPaths.AddRange(fs2);
            List<UserPhotoDemo> users = new List<UserPhotoDemo>();
            foreach (var f in photoPaths)
            {
                users.Add(new UserPhotoDemo { FilePath = f, FileName = System.IO.Path.GetFileName(f) });
            }
            this.ImgViewer.ItemsSource = users;
        }

        public UserPhotoDemo Photos { get; set; }

        public class UserPhotoDemo
        {
            public string FilePath { get; set; }
            public string FileName { get; set; }
        }
    }
}
