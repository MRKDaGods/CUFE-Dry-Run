using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK
{
    public partial class UpdateCourseList : Form
    {
        public UpdateCourseList()
        {
            InitializeComponent();

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

                if (pos.Y < Main.CaptionHeight)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }

                if (pos.X >= ClientSize.Width - Main.GripHeight && pos.Y >= ClientSize.Height - Main.GripHeight)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }
    }
}
