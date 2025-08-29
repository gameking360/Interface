using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Interface.Components
{
    internal class NumberedBorder : Control
    {
        private static int lineHeight;
        private readonly Color myColor;
        private RichTextBox _target;
        private const int FixedWidth = 40;

        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x1;
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private class RichTextBoxScrollListener : NativeWindow
        {
            private readonly Control _invalidateTarget;
            public RichTextBoxScrollListener(RichTextBox rtb, Control invalidateTarget)
            {
                _invalidateTarget = invalidateTarget;
                AssignHandle(rtb.Handle);
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
                {
                    _invalidateTarget.Invalidate();
                }
                base.WndProc(ref m);
            }
        }

        private RichTextBoxScrollListener _scrollListener;

        public NumberedBorder(RichTextBox target)
        {
            this._target = target;
            this.myColor = Color.FromArgb(164, 164, 164);
            this.Parent = _target;
            this.BackColor = _target.BackColor;
            this.Width = FixedWidth;
            this.Height = _target.ClientSize.Height;
            this.Location = new Point(0, 0); // Fixa na parede esquerda
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            _target.Controls.Add(this);
            SetLeftMargin();
            _target.Resize += (s, e) => {
                this.Height = _target.ClientSize.Height;
                this.Location = new Point(0, 0);
                SetLeftMargin();
                this.Invalidate();
            };
            _target.VScroll += (s, e) => this.Invalidate();
            _target.TextChanged += (s, e) => {
                this.Location = new Point(0, 0);
                SetLeftMargin();
                this.Invalidate();
            };
            _scrollListener = new RichTextBoxScrollListener(_target, this);
        }

        private void SetLeftMargin()
        {
            int margin = this.Width;
            SendMessage(_target.Handle, EM_SETMARGINS, (IntPtr)EC_LEFTMARGIN, (IntPtr)(margin));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_target == null) return;
            var g = e.Graphics;
            var font = _target.Font;
            var metrics = g.MeasureString("0", font);
            if (_target.Lines.Length > 1)
            {
                int firstLineIdx = _target.GetFirstCharIndexFromLine(0);
                int secondLineIdx = _target.GetFirstCharIndexFromLine(1);
                lineHeight = _target.GetPositionFromCharIndex(secondLineIdx).Y - _target.GetPositionFromCharIndex(firstLineIdx).Y;
            }
            else
            {
                lineHeight = (int)metrics.Height;
            }
            if (lineHeight <= 0) lineHeight = (int)metrics.Height;
            int visibleLines = Math.Max(_target.ClientSize.Height / lineHeight, 1);
            int firstLine = GetFirstVisibleLine(_target);
            int lineLeft = this.Width - 2;
            for (int i = 0; i < visibleLines && (firstLine + i) < _target.Lines.Length; i++)
            {
                string str = (firstLine + i + 1).ToString();
                int length = str.Length;
                int charIndex = _target.GetFirstCharIndexFromLine(firstLine + i);
                Point pos = _target.GetPositionFromCharIndex(charIndex);
                int py = pos.Y - _target.GetPositionFromCharIndex(_target.GetCharIndexFromPosition(new Point(0, 0))).Y;
                SizeF numSize = g.MeasureString(str, font);
                int px = (int)((this.Width - numSize.Width) / 2);
                g.DrawString(str, font, new SolidBrush(myColor), px, py);
            }
            g.DrawLine(new Pen(myColor), this.Width - 1, 0, this.Width - 1, this.Height);
        }

        private int CalculateLeft(int numLines) => FixedWidth;

        private int GetFirstVisibleLine(RichTextBox rtb)
        {
            int index = rtb.GetCharIndexFromPosition(new Point(0, 0));
            return rtb.GetLineFromCharIndex(index);
        }
    }
}