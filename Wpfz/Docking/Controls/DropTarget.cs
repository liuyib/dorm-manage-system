using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Wpfz.Docking.Layout;
using System.Windows.Threading;

namespace Wpfz.Docking.Controls
{
    abstract class DropTargetBase : DependencyObject
    {
        #region IsDraggingOver

        /// <summary>
        /// IsDraggingOver Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsDraggingOverProperty =
            DependencyProperty.RegisterAttached("IsDraggingOver", typeof(bool), typeof(DropTargetBase),
                new FrameworkPropertyMetadata((bool)false));

        /// <summary>
        /// Gets the IsDraggingOver property.  This dependency property 
        /// indicates if user is dragging a window over the target element.
        /// </summary>
        public static bool GetIsDraggingOver(DependencyObject d)
        {
            return (bool)d.GetValue(IsDraggingOverProperty);
        }

        /// <summary>
        /// Sets the IsDraggingOver property.  This dependency property 
        /// indicates if user is dragging away a window from the target element.
        /// </summary>
        public static void SetIsDraggingOver(DependencyObject d, bool value)
        {
            d.SetValue(IsDraggingOverProperty, value);
        }

        #endregion
    }

    internal abstract class DropTarget<T> : DropTargetBase, IDropTarget where T : FrameworkElement
    {
        protected DropTarget(T targetElement, Rect detectionRect, DropTargetType type)
        {
            _targetElement = targetElement;
            _detectionRect = new Rect[] { detectionRect };
            _type = type;
        }

        protected DropTarget(T targetElement, IEnumerable<Rect> detectionRects, DropTargetType type)
        {
            _targetElement = targetElement;
            _detectionRect = detectionRects.ToArray();
            _type = type;
        }

        Rect[] _detectionRect;

        public Rect[] DetectionRects
        {
            get { return _detectionRect; }
        }


        T _targetElement;
        public T TargetElement
        {
            get { return _targetElement; }
        }

        DropTargetType _type;

        public DropTargetType Type
        {
            get { return _type; }
        }

        protected virtual void Drop(LayoutAnchorableFloatingWindow floatingWindow)
        { }

        protected virtual void Drop(LayoutDocumentFloatingWindow floatingWindow)
        { }


        public void Drop(LayoutFloatingWindow floatingWindow)
        {
            var root = floatingWindow.Root;
            var currentActiveContent = floatingWindow.Root.ActiveContent;
            var fwAsAnchorable = floatingWindow as LayoutAnchorableFloatingWindow;

            if (fwAsAnchorable != null)
            {
                this.Drop(fwAsAnchorable);
            }
            else
            {
                var fwAsDocument = floatingWindow as LayoutDocumentFloatingWindow;
                this.Drop(fwAsDocument);
            }

            Dispatcher.BeginInvoke(new Action(() =>
                {
                    currentActiveContent.IsSelected = false;
                    currentActiveContent.IsActive = false;
                    currentActiveContent.IsActive = true;
                }), DispatcherPriority.Background);
        }

        public virtual bool HitTest(Point dragPoint)
        {
            return _detectionRect.Any(dr => dr.Contains(dragPoint));
        }

        public abstract Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindow);



        public void DragEnter()
        {
            SetIsDraggingOver(TargetElement, true);
        }

        public void DragLeave()
        {
            SetIsDraggingOver(TargetElement, false);
        }
    }
}
