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

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public NumberedBorder(RichTextBox target)
        {
            this._target = target;
            this.myColor = Color.FromArgb(164, 164, 164);
            this.Parent = _target;
            this.BackColor = _target.BackColor;
            this.Width = FixedWidth;
            this.Location = new Point(0, 0); // Fixa na parede esquerda
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            _target.Controls.Add(this);
            SetLeftMargin();
            UpdateHeight();
            _target.Resize += (s, e) => {
                this.Location = new Point(0, 0);
                SetLeftMargin();
                UpdateHeight();
                this.Invalidate();
            };
            _target.VScroll += (s, e) => this.Invalidate();
            _target.TextChanged += (s, e) => {
                this.Location = new Point(0, 0);
                SetLeftMargin();
                UpdateHeight();
                this.Invalidate();
            };
        }

        private void UpdateHeight()
        {
            using (var g = _target.CreateGraphics())
            {
                var font = _target.Font;
                var metrics = g.MeasureString("0", font);
                int totalLines = Math.Max(_target.Lines.Length, 1);
                int totalHeight = (int)(metrics.Height * totalLines);
                this.Height = Math.Max(_target.ClientSize.Height, totalHeight);
            }
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
            int lineHeightLocal = (int)metrics.Height;
            int visibleLines = Math.Max(_target.ClientSize.Height / lineHeightLocal, 1);
            int firstLine = GetFirstVisibleLine(_target);
            int maxLines = Math.Max(_target.Lines.Length, firstLine + visibleLines);
            // Exibe até 999 linhas numeradas
            int lastLine = Math.Max(maxLines, 999);
            for (int i = 0; i < visibleLines; i++)
            {
                int lineNumber = firstLine + i + 1;
                if (lineNumber > lastLine) break;
                string str = lineNumber.ToString();
                SizeF numSize = g.MeasureString(str, font);
                int px = (int)((this.Width - numSize.Width) / 2);
                int py = i * lineHeightLocal;
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
