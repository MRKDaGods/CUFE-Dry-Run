using MRK.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MRK
{
    public partial class Utils
    {
        private const uint ENABLE_QUICK_EDIT = 0x0040;
        private const int STD_INPUT_HANDLE = -10;

        public static bool RectOverlaps(Rectangle rectA, Rectangle rectB)
        {
            return Math.Max(rectA.Left, rectB.Left) < Math.Min(rectA.Right, rectB.Right)
                && Math.Max(rectA.Top, rectB.Top) < Math.Min(rectA.Bottom, rectB.Bottom);
        }

        public static void CenterControl(Control c)
        {
            c.Location = new Point(c.Parent!.Size.Width / 2 - c.Width / 2, c.Location.Y);
        }

        public static void InitializeConsole()
        {
            AllocConsole();

            // turn off selection
            var hConsole = GetStdHandle(STD_INPUT_HANDLE);
            GetConsoleMode(hConsole, out var mode);

            mode &= ~ENABLE_QUICK_EDIT;

            SetConsoleMode(hConsole, mode);
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

        public static string GetFeaturesString(UpdateFeatures features)
        {
            return string.Join(" | ", [
                ..Enum.GetValues<UpdateFeatures>()
                .Skip(1)
                .Where(x => features.HasFlag(x))
                .Select(x => x.ToString())
                .ToArray(),
            ]);
        }

        [LibraryImport("kernel32.dll")]
        private static partial nint GetConsoleWindow();

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetForegroundWindow(nint hWnd);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(nint hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(nint hConsoleHandle, uint dwMode);
    }
}
