using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Wpfz.Docking.Controls
{
    interface IOverlayWindowDropTarget
    {
        Rect ScreenDetectionArea { get; }

        OverlayWindowDropTargetType Type { get; }
    }

    public class OverlayWindowDropTarget : IOverlayWindowDropTarget
    {
        internal OverlayWindowDropTarget(IOverlayWindowArea overlayArea, OverlayWindowDropTargetType targetType, FrameworkElement element)
        {
            _overlayArea = overlayArea;
            _type = targetType;
            _screenDetectionArea = new Rect(element.TransformToDeviceDPI(new Point()), element.TransformActualSizeToAncestor());
        }

        IOverlayWindowArea _overlayArea;

        Rect _screenDetectionArea;
        Rect IOverlayWindowDropTarget.ScreenDetectionArea
        {
            get
            {
                return _screenDetectionArea;
            }

        }

        OverlayWindowDropTargetType _type;
        OverlayWindowDropTargetType IOverlayWindowDropTarget.Type
        {
            get { return _type; }
        }


    }

    public enum OverlayWindowDropTargetType
    {
        DockingManagerDockLeft,
        DockingManagerDockTop,
        DockingManagerDockRight,
        DockingManagerDockBottom,

        DocumentPaneDockLeft,
        DocumentPaneDockTop,
        DocumentPaneDockRight,
        DocumentPaneDockBottom,
        DocumentPaneDockInside,

        AnchorablePaneDockLeft,
        AnchorablePaneDockTop,
        AnchorablePaneDockRight,
        AnchorablePaneDockBottom,
        AnchorablePaneDockInside,
    }
}
