using Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace Helper
{
    class Helpers
    {
        /// <summary>
        /// A Generic Clamp Function for C#
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }


        /// <summary>
        /// return is existed full screen application at now
        /// </summary>
        /// <returns></returns>
        public static bool IsExistedFullscreen()
        {
            bool bFullScreen = false;
            IntPtr hWnd = Winapi.GetForegroundWindow();
            Winapi.RECT rcApp, rcDesk;
            Winapi.GetWindowRect(Winapi.GetDesktopWindow(), out rcDesk);
            if (hWnd != Winapi.GetDesktopWindow() && hWnd != Winapi.GetShellWindow())
            {
                Winapi.GetWindowRect(hWnd, out rcApp);
                if (rcApp.left <= rcDesk.left
                    && rcApp.top <= rcDesk.top
                    && rcApp.right >= rcDesk.right
                    && rcApp.bottom >= rcDesk.bottom)
                {
                    bFullScreen = true;
                }
            }
            return bFullScreen;
        }

    }
}
