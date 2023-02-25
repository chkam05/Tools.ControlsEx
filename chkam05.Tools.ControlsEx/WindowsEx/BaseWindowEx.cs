using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace chkam05.Tools.ControlsEx.WindowsEx
{
    public class BaseWindowEx : Window, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        protected double _posTop, _posLeft;
        protected double _startW, _startH;
        protected double _startX, _startY;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseWindowEx class constructor. </summary>
        public BaseWindowEx() : base()
        {
            //
        }

        #endregion CLASS METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Maximize or Restore window. </summary>
        public void Maximize()
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Minimize window. </summary>
        public void Minimize()
        {
            WindowState = WindowState.Minimized;
        }

        #endregion MANAGEMENT METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region RESIZE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Start window resize procedure. </summary>
        /// <param name="resizeBorder"> Resize border. </param>
        /// <param name="cursorXPos"> Current cursor X position. </param>
        /// <param name="cursorYPos"> Current cursor Y position. </param>
        protected void ResizeStart(Border resizeBorder, double cursorXPos, double cursorYPos)
        {
            _posTop = Top;
            _posLeft = Left;
            _startX = cursorXPos;
            _startY = cursorYPos;
            _startW = Width;
            _startH = Height;

            switch (resizeBorder.Name)
            {
                case "ResizeBorderTopLeft":
                    Cursor = Cursors.SizeNWSE;
                    break;
                case "ResizeBorderTopRight":
                    Cursor = Cursors.SizeNESW;
                    break;
                case "ResizeBorderBottomLeft":
                    Cursor = Cursors.SizeNESW;
                    break;
                case "ResizeBorderBottomRight":
                    Cursor = Cursors.SizeNWSE;
                    break;
                case "ResizeBorderTop":
                    Cursor = Cursors.SizeNS;
                    break;
                case "ResizeBorderLeft":
                    Cursor = Cursors.SizeWE;
                    break;
                case "ResizeBorderRight":
                    Cursor = Cursors.SizeWE;
                    break;
                case "ResizeBorderBottom":
                    Cursor = Cursors.SizeNS;
                    break;
            }

            resizeBorder.CaptureMouse();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Resize window. </summary>
        /// <param name="resizeBorder"> Resize border. </param>
        /// <param name="cursorXPos"> Current cursor X position. </param>
        /// <param name="cursorYPos"> Current cursor Y position. </param>
        protected void ResizeMove(Border resizeBorder, double cursorXPos, double cursorYPos)
        {
            double x = cursorXPos;
            double y = cursorYPos;
            double fX = System.Windows.Forms.Cursor.Position.X;
            double fY = System.Windows.Forms.Cursor.Position.Y;
            double w = Width;
            double h = Height;

            switch (resizeBorder.Name)
            {
                case "ResizeBorderTopLeft":
                    w = _startW - (fX - _posLeft);
                    h = _startH - (fY - _posTop);

                    if (w < MinWidth)
                        w = MinWidth;

                    if (h < MinHeight)
                        h = MinHeight;

                    if (w > MinWidth)
                        Left = fX;

                    if (h > MinHeight)
                        Top = fY;
                    break;

                case "ResizeBorderTopRight":
                    w = _startW + (x - _startX);
                    h = _startH - (fY - _posTop);

                    if (w < MinWidth)
                        w = MinWidth;

                    if (h < MinHeight)
                        h = MinHeight;

                    if (h > MinHeight)
                        Top = fY;
                    break;

                case "ResizeBorderBottomLeft":
                    w = _startW - (fX - _posLeft);
                    h = _startH + (y - _startY);

                    if (w < MinWidth)
                        w = MinWidth;

                    if (h < MinHeight)
                        h = MinHeight;

                    if (w > MinWidth)
                        Left = fX;
                    break;

                case "ResizeBorderBottomRight":
                    w = _startW + (x - _startX);
                    h = _startH + (y - _startY);

                    if (w < MinWidth)
                        w = MinWidth;

                    if (h < MinHeight)
                        h = MinHeight;
                    break;

                case "ResizeBorderTop":
                    h = _startH - (fY - _posTop);

                    if (h < MinHeight)
                        h = MinHeight;

                    if (h > MinHeight)
                        Top = fY;
                    break;

                case "ResizeBorderLeft":
                    w = _startW - (fX - _posLeft);

                    if (w < MinWidth)
                        w = MinWidth;

                    if (w > MinWidth)
                        Left = fX;
                    break;

                case "ResizeBorderRight":
                    w = _startW + (x - _startX);

                    if (w < MinWidth)
                        w = MinWidth;
                    break;

                case "ResizeBorderBottom":
                    h = _startH + (y - _startY);

                    if (h < MinHeight)
                        h = MinHeight;
                    break;
            }

            if (w >= MinWidth)
                Width = w;

            if (h >= MinHeight)
                Height = h;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Finalize windows resize procedure. </summary>
        /// <param name="resizeBorder"> Resize border. </param>
        protected void ResizeEnd(Border resizeBorder)
        {
            resizeBorder.ReleaseMouseCapture();
            Cursor = Cursors.Arrow;
        }

        #endregion RESIZE METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get Border from ContentTemplate. </summary>
        /// <param name="borderName"> Border name. </param>
        /// <returns> Border or null. </returns>
        protected Border GetBorder(string borderName)
        {
            return this.Template.FindName(borderName, this) as Border;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ButtonEx from ContentTemplate. </summary>
        /// <param name="buttonName"> ButtonEx name. </param>
        /// <returns> ButtonEx or null. </returns>
        protected ButtonEx GetButton(string buttonName)
        {
            return this.Template.FindName(buttonName, this) as ButtonEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get Image from ContentTemplate. </summary>
        /// <param name="imageName"> Image name. </param>
        /// <returns> Image or null. </returns>
        protected Image GetImage(string imageName)
        {
            return this.Template.FindName(imageName, this) as Image;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ButtonEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyClickMethod(ButtonEx buttonEx, RoutedEventHandler eventHandler)
        {
            if (buttonEx != null)
                buttonEx.Click += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseLeftButtonDown method on Border. </summary>
        /// <param name="border"> Border. </param>
        /// <param name="eventHandler"> Mouse Left Button Down method. </param>
        protected void ApplyMouseLeftButtonDown(Border border, MouseButtonEventHandler eventHandler)
        {
            if (border != null)
                border.MouseLeftButtonDown += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseLeftButtonUp method on Border. </summary>
        /// <param name="border"> Border. </param>
        /// <param name="eventHandler"> Mouse Left Button Up method. </param>
        protected void ApplyMouseLeftButtonUp(Border border, MouseButtonEventHandler eventHandler)
        {
            if (border != null)
                border.MouseLeftButtonUp += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseMove method on Border. </summary>
        /// <param name="border"> Border. </param>
        /// <param name="eventHandler"> Mouse Move method. </param>
        protected void ApplyMouseMove(Border border, MouseEventHandler eventHandler)
        {
            if (border != null)
                border.MouseMove += eventHandler;
        }

        #endregion TEMPLATE METHODS

    }
}
