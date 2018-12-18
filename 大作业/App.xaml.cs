using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace 大作业
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 动态应用所选的主题(皮肤)
        /// </summary>
        /// <param name="item">主题项(皮肤)</param>
        public void ApplySkin(string skinName)
        {
            Uri[] skinDictUri = new Uri[1];
            switch (skinName)
            {
                case "Generic":
                    skinDictUri[0] = new Uri("/Wpfz;component/Themes/GenericThemes.xaml", UriKind.Relative);
                    break;
                case "Aero":
                    skinDictUri[0] = new Uri("/Wpfz;component/Themes/AeroThemes.xaml", UriKind.Relative);
                    break;
                case "Blue":
                    skinDictUri[0] = new Uri("/Wpfz;component/Themes/BlueThemes.xaml", UriKind.Relative);
                    break;
            }
            Collection<ResourceDictionary> mergedDicts = Resources.MergedDictionaries;
            if (mergedDicts.Count > 0)
            {
                mergedDicts.Clear();
            }
            foreach (var v in skinDictUri)
            {
                ResourceDictionary skinDict = LoadComponent(v) as ResourceDictionary;
                mergedDicts.Add(skinDict);
            }
        }
    }
}
