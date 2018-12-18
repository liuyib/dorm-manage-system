﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpfz.Docking.Layout
{
    [ContentProperty("Children")]
    [Serializable]
    public class LayoutPanel : LayoutPositionableGroup<ILayoutPanelElement>, ILayoutPanelElement, ILayoutOrientableGroup
    {
        public LayoutPanel()
        {

        }

        public LayoutPanel(ILayoutPanelElement firstChild)
        {
            Children.Add(firstChild);
        }


        #region Orientation

        private Orientation _orientation;
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (_orientation != value)
                {
                    RaisePropertyChanging("Orientation");
                    _orientation = value;
                    RaisePropertyChanged("Orientation");
                }
            }
        }

        #endregion


        protected override bool GetVisibility()
        {
            return Children.Any(c => c.IsVisible);
        }

        public override void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Orientation", Orientation.ToString());
            base.WriteXml(writer);
        }

        public override void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader.MoveToAttribute("Orientation"))
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), reader.Value, true);
            base.ReadXml(reader);
        }

#if TRACE
        public override void ConsoleDump(int tab)
        {
          System.Diagnostics.Trace.Write( new string( ' ', tab * 4 ) );
          System.Diagnostics.Trace.WriteLine( string.Format( "Panel({0})", Orientation ) );

          foreach (LayoutElement child in Children)
              child.ConsoleDump(tab + 1);
        }
#endif
    }
}
