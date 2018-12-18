﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Wpfz.Docking.Layout
{
    public interface ILayoutElement : INotifyPropertyChanged, INotifyPropertyChanging
    {
        ILayoutContainer Parent { get; }
        ILayoutRoot Root { get; }
    }
}
