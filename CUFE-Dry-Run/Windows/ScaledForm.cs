using System;
using System.Drawing;
using System.Windows.Forms;

namespace MRK
{
    public partial class ScaledForm : Form
    {
        private const int ResizeBorderWidth = 8;
        private const int ResizeCornerSize = 16;
        private const int CaptionHeight = 64;
        private const int BorderWidth = 1;

        private readonly bool _useTransparency;
        private bool _blurEnabled;

        public ScaledForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected virtual void ScaleForm()
        {
            // Since this is designed on 2560x1440, scale accordingly
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
            // Handle hit testing for resize and caption areas
            if (m.Msg == 0x84) // WM_NCHITTEST
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                // Don't allow resize when maximized
                if (WindowState == FormWindowState.Maximized)
                {
                    if (pos.Y < CaptionHeight)
                    {
                        m.Result = 2; // HTCAPTION
                        return;
                    }
                    base.WndProc(ref m);
                    return;
                }

                var hitTest = GetHitTestResult(pos);
                if (hitTest != 0)
                {
                    m.Result = hitTest;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private int GetHitTestResult(Point pos)
        {
            var clientRect = ClientRectangle;

            // Caption area (for dragging)
            if (pos.Y < CaptionHeight && pos.Y >= 0 && pos.X >= 0 && pos.X < clientRect.Width)
            {
                // Check if we're in a corner first
                if (pos.Y < ResizeCornerSize)
                {
                    if (pos.X < ResizeCornerSize)
                        return 13; // HTTOPLEFT
                    if (pos.X >= clientRect.Width - ResizeCornerSize)
                        return 14; // HTTOPRIGHT
                }
                
                // Check if we're on the top border
                if (pos.Y < ResizeBorderWidth)
                    return 12; // HTTOP
                
                return 2; // HTCAPTION
            }

            // Bottom edge and corners
            if (pos.Y >= clientRect.Height - ResizeBorderWidth)
            {
                if (pos.X < ResizeCornerSize)
                    return 16; // HTBOTTOMLEFT
                if (pos.X >= clientRect.Width - ResizeCornerSize)
                    return 17; // HTBOTTOMRIGHT
                return 15; // HTBOTTOM
            }

            // Top edge and corners (when not in caption area)
            if (pos.Y < ResizeBorderWidth)
            {
                if (pos.X < ResizeCornerSize)
                    return 13; // HTTOPLEFT
                if (pos.X >= clientRect.Width - ResizeCornerSize)
                    return 14; // HTTOPRIGHT
                return 12; // HTTOP
            }

            // Left edge
            if (pos.X < ResizeBorderWidth)
            {
                if (pos.Y < ResizeCornerSize)
                    return 13; // HTTOPLEFT
                if (pos.Y >= clientRect.Height - ResizeCornerSize)
                    return 16; // HTBOTTOMLEFT
                return 10; // HTLEFT
            }

            // Right edge
            if (pos.X >= clientRect.Width - ResizeBorderWidth)
            {
                if (pos.Y < ResizeCornerSize)
                    return 14; // HTTOPRIGHT
                if (pos.Y >= clientRect.Height - ResizeCornerSize)
                    return 17; // HTBOTTOMRIGHT
                return 11; // HTRIGHT
            }

            return 0; // Not in a resize area
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw border
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var borderColor = Color.FromArgb(64, 255, 255, 255);
            var highlightColor = Color.FromArgb(96, 255, 255, 255);

            // Main border
            using (var borderPen = new Pen(borderColor, BorderWidth))
            {
                var borderRect = new Rectangle(BorderWidth / 2, BorderWidth / 2,
                    Width - BorderWidth, Height - BorderWidth);
                g.DrawRectangle(borderPen, borderRect);
            }

            // Corner accents
            if (WindowState != FormWindowState.Maximized)
            {
                using var accentBrush = new SolidBrush(Color.FromArgb(64, 255, 255, 255));
                var cornerSize = 4;
                var margin = 6;

                // Bottom-right corner accent
                g.FillEllipse(accentBrush, Width - margin - cornerSize, Height - margin - cornerSize, cornerSize, cornerSize);

                // Other corner accents
                using var subtleAccentBrush = new SolidBrush(Color.FromArgb(32, 255, 255, 255));
                g.FillEllipse(subtleAccentBrush, margin, Height - margin - cornerSize, cornerSize, cornerSize); // Bottom-left
            }
        }
    }
}
