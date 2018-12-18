﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpfz.Docking.Layout
{
    public interface ILayoutPane : ILayoutContainer, ILayoutElementWithVisibility
    {
        void MoveChild(int oldIndex, int newIndex);

        void RemoveChildAt(int childIndex);
    }
}
