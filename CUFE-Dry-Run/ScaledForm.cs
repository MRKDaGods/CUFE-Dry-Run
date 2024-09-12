using System;
using System.Drawing;
using System.Linq;
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
        private bool _blurEnabled;

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

            //RegisterForTransparency(this);

            base.OnLoad(e);
        }

        protected void RegisterForTransparency(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is Panel)
                {
                    RegisterForTransparency(c);
                    continue;
                }

                if (c.BackColor == Color.Transparent)
                {
                    c.Paint += (o, e) =>
                    {
                        if (_useTransparency && _blurEnabled)
                        {
                            c.BackColor = Color.Black;
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), e.ClipRectangle);
                        }
                        else
                        {
                            c.BackColor = Color.Transparent;
                        }
                    };
                }
            }
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
            // rounded corners
            int roundedCorners = 2;
            DwmSetWindowAttribute(Handle, 33, ref roundedCorners, Marshal.SizeOf(typeof(int)));

            if (_useTransparency)
            {
                EnableBlur();
            }
        }

        protected void EnableBlur()
        {
            _blurEnabled = true;

            var accent = new AccentPolicy { AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND };
            ApplyAccentPolicy(accent);

            var intSize = Marshal.SizeOf(typeof(int));

            // Enable immersive dark mode (DWMWA_USE_IMMERSIVE_DARK_MODE: 20)
            int darkMode = 1; // 1 for dark mode enabled
            DwmSetWindowAttribute(Handle, 20, ref darkMode, intSize);

            // Enable Mica material for below Windows build 22523 (DWMWA_MICA_EFFECT: 1029)
            int micaEnabledBelow22523 = 1; // 1 to enable
            DwmSetWindowAttribute(Handle, 1029, ref micaEnabledBelow22523, intSize);

            // Enable Mica material for Windows 22523 and up (DWMWA_SYSTEMBACKDROP_TYPE: 38)
            int micaEnabled = 2; // 2 for Mica effect
            DwmSetWindowAttribute(Handle, 38, ref micaEnabled, intSize);
        }

        protected void DisableBlur()
        {
            _blurEnabled = false;

            var accent = new AccentPolicy { AccentState = AccentState.ACCENT_DISABLED };
            ApplyAccentPolicy(accent);
        }

        private void ApplyAccentPolicy(AccentPolicy accent)
        {
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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_useTransparency && _blurEnabled)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), e.ClipRectangle);
            }

            base.OnPaint(e);
        }

        [LibraryImport("user32.dll")]
        private static partial int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [LibraryImport("DwmApi")]
        private static partial int DwmSetWindowAttribute(IntPtr hwnd, uint attr, ref int attrValue, int attrSize);
    }
}
