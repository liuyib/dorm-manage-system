using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfz.Docking.Layout;

namespace Wpfz.Docking
{
    class LayoutEventArgs : EventArgs
    {
        public LayoutEventArgs(LayoutRoot layoutRoot)
        {
            LayoutRoot = layoutRoot;
        }
        public LayoutRoot LayoutRoot { get; private set; }
    }
}
