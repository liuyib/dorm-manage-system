﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Wpfz.Docking.Layout;

namespace Wpfz.Docking.Controls
{
    public class AnchorablePaneControlOverlayArea : OverlayArea
    {
        internal AnchorablePaneControlOverlayArea(
            IOverlayWindow overlayWindow, 
            LayoutAnchorablePaneControl anchorablePaneControl)
            : base(overlayWindow)
        {

            _anchorablePaneControl = anchorablePaneControl;
            base.SetScreenDetectionArea(new Rect(
                _anchorablePaneControl.PointToScreenDPI(new Point()),
                _anchorablePaneControl.TransformActualSizeToAncestor()));

        }

        LayoutAnchorablePaneControl _anchorablePaneControl;
    }
}
