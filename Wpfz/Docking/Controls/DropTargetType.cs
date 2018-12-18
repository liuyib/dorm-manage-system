﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpfz.Docking.Controls
{
    public enum DropTargetType
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

        DocumentPaneGroupDockInside,

        AnchorablePaneDockLeft,
        AnchorablePaneDockTop,
        AnchorablePaneDockRight,
        AnchorablePaneDockBottom,
        AnchorablePaneDockInside,

        DocumentPaneDockAsAnchorableLeft,
        DocumentPaneDockAsAnchorableTop,
        DocumentPaneDockAsAnchorableRight,
        DocumentPaneDockAsAnchorableBottom,
    }
}
