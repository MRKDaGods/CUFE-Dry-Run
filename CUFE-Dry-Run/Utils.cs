using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MRK
{
    public partial class Utils
    {
        public static bool RectOverlaps(Rectangle rectA, Rectangle rectB)
        {
            return Math.Max(rectA.Left, rectB.Left) < Math.Min(rectA.Right, rectB.Right)
                && Math.Max(rectA.Top, rectB.Top) < Math.Min(rectA.Bottom, rectB.Bottom);
        }

        public static void CenterControl(Control c)
        {
            c.Location = new Point(c.Parent!.Size.Width / 2 - c.Width / 2, c.Location.Y);
        }

        public static void BringConsoleToFront()
        {
            SetForegroundWindow(GetConsoleWindow());
        }

        public static void OpenURL(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true,
            });
        }

        [LibraryImport("kernel32.dll")]
        private static partial nint GetConsoleWindow();

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetForegroundWindow(nint hWnd);
    }
}
