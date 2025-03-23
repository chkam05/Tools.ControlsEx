using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace chkam05.Tools.ControlsEx.Example.Utilities
{
    public static class ScreenUtilities
    {

        //  METHODS

        #region SCREEN

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a list of connected screens. </summary>
        /// <returns> List of connected screens. </returns>
        public static List<Screen> GetAllScreens()
        {
            return Screen.AllScreens.ToList();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns the screen where the window is located. </summary>
        /// <param name="window"> The window on the screen. </param>
        /// <returns> Screen where the window is located. </returns>
        public static Screen GetScreenFromWindow(Window window)
        {
            var windowInterop = new WindowInteropHelper(window);
            IntPtr hwnd = windowInterop.Handle;

            return hwnd != IntPtr.Zero ? Screen.FromHandle(hwnd) : null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns the entire area where content can be displayed. </summary>
        /// <returns> Area where content can be displayed. </returns>
        public static Rect GetDisplayBounds()
        {
            var rect = SystemInformation.VirtualScreen;
            return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a workspace area where content can be displayed. </summary>
        /// <returns> Workspace area where content can be displayed. </returns>
        public static Rect GetWorkingArea()
        {
            var rect = Screen.AllScreens.Aggregate(System.Drawing.Rectangle.Empty, (acc, screen) => System.Drawing.Rectangle.Union(acc, screen.WorkingArea));
            return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
        }

        #endregion SCREEN

        #region WINDOW

        //  --------------------------------------------------------------------------------
        /// <summary> Fix window position on screen. </summary>
        /// <param name="window"> The window whose position on the screen has to be fixed. </param>
        public static void FixWindowPosition(Window window)
        {
            var windowInterop = new WindowInteropHelper(window);
            IntPtr hwnd = windowInterop.Handle;

            if (hwnd == IntPtr.Zero)
                return;

            var currentScreen = GetScreenFromWindow(window);
            var screenBounds = GetWorkingArea();

            double posX = window.Left;
            double posY = window.Top;
            double width = window.Width;
            double height = window.Height;

            if (posX < screenBounds.Left)
                posX = screenBounds.Left;

            if (posY < screenBounds.Top)
                posY = screenBounds.Top;

            if (posX + width > screenBounds.Right)
            {
                posX = screenBounds.Right - width;

                if (posX < screenBounds.Left)
                {
                    posX = screenBounds.Left;
                    width = screenBounds.Width;
                }
            }

            if (posY + height > screenBounds.Bottom)
            {
                posY = screenBounds.Bottom - height;
                if (posY < screenBounds.Top)
                {
                    posY = screenBounds.Top;
                    height = screenBounds.Height;
                }
            }

            window.Left = posX;
            window.Top = posY;
            window.Width = width;
            window.Height = height;
        }

        #endregion WINDOW

    }
}
