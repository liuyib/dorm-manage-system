﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpfz.Docking.Layout
{
    public interface ILayoutPanelElement : ILayoutElement
    {
        bool IsVisible { get; }
    }
}
