using System;
using System.Drawing;
using System.Windows.Forms;

namespace MRK
{
    public class MRKForm : Form
    {
        private const int GripHeight = 16;
        private const int CaptionHeight = 64;

        protected void ScaleForm()
        {
            //since this is designed on 2560x1440, scale accordingly
            var bounds = Screen.FromControl(this).Bounds;
            Size = new Size((int)(Size.Width * (bounds.Width / 2560f)), (int)(Size.Height * (bounds.Height / 1440f)));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < CaptionHeight)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }

                if (pos.X >= ClientSize.Width - GripHeight && pos.Y >= ClientSize.Height - GripHeight)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }
    }
}
