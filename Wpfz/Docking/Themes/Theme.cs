﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpfz.Docking.Themes
{
    public abstract class Theme : DependencyObject
    {
        public Theme()
        {

        }

        public abstract Uri GetResourceUri();
    }
}
