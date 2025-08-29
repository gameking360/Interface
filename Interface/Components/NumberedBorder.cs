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
            this.Height = _target.ClientSize.Height;
            this.Location = new Point(0, 0); // Fixa na parede esquerda
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
            int lineHeight = (int)metrics.Height;
            int totalLines = _target.GetLineFromCharIndex(_target.TextLength) + 1;
            int firstVisibleLine = GetFirstVisibleLine(_target);
            int lastVisibleLine = totalLines - 1;
            // Estima o último visível
            for (int i = firstVisibleLine; i < totalLines; i++)
            {
                int charIdx = _target.GetFirstCharIndexFromLine(i);
                Point pos = charIdx >= 0 ? _target.GetPositionFromCharIndex(charIdx) : new Point(0, (i - firstVisibleLine) * lineHeight);
                if (pos.Y > _target.ClientSize.Height)
                {
                    lastVisibleLine = i;
                    break;
                }
            }
            for (int i = firstVisibleLine; i <= lastVisibleLine; i++)
            {
                int charIdx = _target.GetFirstCharIndexFromLine(i);
                Point pos;
                if (charIdx >= 0)
                    pos = _target.GetPositionFromCharIndex(charIdx);
                else
                {
                    // Linha vazia, calcula posição manualmente
                    int y0 = 0;
                    if (firstVisibleLine < totalLines && _target.GetFirstCharIndexFromLine(firstVisibleLine) >= 0)
                        y0 = _target.GetPositionFromCharIndex(_target.GetFirstCharIndexFromLine(firstVisibleLine)).Y;
                    pos = new Point(0, y0 + (i - firstVisibleLine) * lineHeight);
                }
                string str = (i + 1).ToString();
                SizeF numSize = g.MeasureString(str, font);
                int px = (int)((this.Width - numSize.Width) / 2);
                int py = pos.Y;
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
