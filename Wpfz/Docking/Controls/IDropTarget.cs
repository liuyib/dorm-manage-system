using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Wpfz.Docking.Layout;

namespace Wpfz.Docking.Controls
{
    internal interface IDropTarget
    {
        Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindow);

        bool HitTest(Point dragPoint);

        DropTargetType Type { get; }

        void Drop(LayoutFloatingWindow floatingWindow);

        void DragEnter();

        void DragLeave();
    }
}
