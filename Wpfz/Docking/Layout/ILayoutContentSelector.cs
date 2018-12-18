﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpfz.Docking.Layout
{
    public interface ILayoutContentSelector
    {
        int SelectedContentIndex { get; set; }

        int IndexOf(LayoutContent content);

        LayoutContent SelectedContent { get; }
    }
}
