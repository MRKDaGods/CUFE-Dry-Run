using System;
using System.Drawing;
using System.Windows.Forms;

namespace MRK
{
    public class Utils
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
    }
}
