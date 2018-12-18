using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpfz.Docking.Themes
{
    public abstract class DictionaryTheme : Theme
    {
        public DictionaryTheme(ResourceDictionary themeResourceDictionary)
        {
            this.ThemeResourceDictionary = themeResourceDictionary;
        }

        public ResourceDictionary ThemeResourceDictionary { get; private set; }

        public override Uri GetResourceUri()
        {
            return null;
        }
    }
}
