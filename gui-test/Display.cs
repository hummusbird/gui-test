using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace gui_test
{
    public class Window
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        static readonly IntPtr ptr = Process.GetCurrentProcess().MainWindowHandle;
        static Rect WindowRect = new Rect();

        public static Rect GetPosition() // Get the console window's current position
        {
            GetWindowRect(ptr, ref WindowRect);
            return WindowRect;
        }

        public static Mouse.POINT GetMousePosition(bool rows = true) // Get the mouse position in relation to the console window
        {
            Mouse.POINT point = Mouse.GetPosition();
            Window.Rect rect = GetPosition();

            Mouse.POINT winpoint = point;

            winpoint.X = point.X - rect.Left - 8;
            winpoint.Y = point.Y - rect.Top - 31;

            if (winpoint.X < 0) { winpoint.X = 0; }
            if (winpoint.Y < 0) { winpoint.Y = 0; }

            if (point.X > GetPosition().Right - 25) { winpoint.X = rect.Right - rect.Left - 33; }
            if (point.Y > GetPosition().Bottom - 8) { winpoint.Y = rect.Bottom - rect.Top - 39; }

            if (rows)
            {
                winpoint.X /= 8;
                winpoint.Y /= 16;
            }
            return winpoint;
        }
    }

    public static class Mouse
    {

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int button);
        public static bool MDown(MouseButton button)
        {
            return GetAsyncKeyState((int)button);
        }
        public enum MouseButton
        {
            Left = 0x01,
            Right = 0x02,
            Middle = 0x04,
        }

        public struct POINT
        {
            public int X;
            public int Y;
        }

        public static POINT GetPosition() // Get the mouse position in relation to the display
        {
            GetCursorPos(out POINT point);
            return point;
        }
    }
}
