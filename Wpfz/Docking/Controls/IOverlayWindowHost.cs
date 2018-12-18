﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpfz.Docking.Controls
{
    internal interface IOverlayWindowHost
    {
        bool HitTest(Point dragPoint);

        IOverlayWindow ShowOverlayWindow(LayoutFloatingWindowControl draggingWindow);

        void HideOverlayWindow();

        IEnumerable<IDropArea> GetDropAreas(LayoutFloatingWindowControl draggingWindow);

        DockingManager Manager { get; }
    }
}
