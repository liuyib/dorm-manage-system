using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpfz.Docking.Layout
{
    public class LayoutElementEventArgs : EventArgs
    {
        public LayoutElementEventArgs(LayoutElement element)
        {
            Element = element;
        }

        public LayoutElement Element { get; private set; }
    }
}
