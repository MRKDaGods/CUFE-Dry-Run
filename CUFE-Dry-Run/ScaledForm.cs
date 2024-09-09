using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MRK
{
    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    internal enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    public partial class ScaledForm : Form
    {
        private const int GripHeight = 16;
        private const int CaptionHeight = 64;

        private readonly bool _useTransparency;

        public ScaledForm() : this(false)
        {
        }

        public ScaledForm(bool useTransparency)
        {
            _useTransparency = useTransparency;

            SetupWindow();
        }

        protected virtual void ScaleForm()
        {
            //since this is designed on 2560x1440, scale accordingly
            var bounds = Screen.FromControl(this).Bounds;
            Size = new Size((int)(Size.Width * (bounds.Width / 2560f)), (int)(Size.Height * (bounds.Height / 1440f)));
        }

        protected override void OnLoad(EventArgs e)
        {
            ScaleForm();
            CenterToScreen();

            base.OnLoad(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < CaptionHeight)
                {
                    m.Result = 2;  // HTCAPTION
                    return;
                }

                if (pos.X >= ClientSize.Width - GripHeight && pos.Y >= ClientSize.Height - GripHeight)
                {
                    m.Result = 17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void SetupWindow()
        {
            var intSize = Marshal.SizeOf(typeof(int));

            // rounded corners
            DwmSetWindowAttribute(Handle, 33, [2], intSize);

            if (_useTransparency)
            {
                var accent = new AccentPolicy { AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND };

                var accentStructSize = Marshal.SizeOf(accent);
                var accentPtr = Marshal.AllocHGlobal(accentStructSize);
                Marshal.StructureToPtr(accent, accentPtr, false);

                var data = new WindowCompositionAttributeData
                {
                    Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                    SizeOfData = accentStructSize,
                    Data = accentPtr
                };

                SetWindowCompositionAttribute(Handle, ref data);
                Marshal.FreeHGlobal(accentPtr);

                // immersive dark mode
                DwmSetWindowAttribute(Handle, 20, [1], intSize);

                // Mica for below 22523
                DwmSetWindowAttribute(Handle, 1029, [1], intSize);

                // Mica for 22523 and up
                DwmSetWindowAttribute(Handle, 38, [2], intSize);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_useTransparency)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), e.ClipRectangle);
            }

            base.OnPaint(e);
        }

        [LibraryImport("user32.dll")]
        private static partial int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [LibraryImport("DwmApi")]
        private static partial int DwmSetWindowAttribute(IntPtr hwnd, uint attr, [In] int[] attrValue, int attrSize);
    }
}
