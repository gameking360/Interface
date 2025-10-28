using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface.Components
{
    public partial class NumberedBorder2 : Control
    {
        private readonly RichTextBox _richTextBox;
        private readonly RichTextBox _lineNumberBox;

        public NumberedBorder2(RichTextBox richTextBox, RichTextBox lineNumberBox)
        {
            InitializeComponent();

            _richTextBox = richTextBox;
            _lineNumberBox = lineNumberBox;

            // Configura o lineNumberBox para parecer uma barra lateral
            _lineNumberBox.ReadOnly = true;
            _lineNumberBox.BackColor = Color.LightGray;
            _lineNumberBox.BorderStyle = BorderStyle.None;
            _lineNumberBox.ScrollBars = RichTextBoxScrollBars.None;
            _lineNumberBox.Font = _richTextBox.Font;
            _lineNumberBox.SelectionAlignment = HorizontalAlignment.Center;

            // Eventos para manter sincronizado
            _richTextBox.VScroll += (s, e) => AddLineNumbers();
           // _richTextBox.TextChanged += (s, e) => AddLineNumbers();
            _richTextBox.SelectionChanged += (s, e) => AddLineNumbers();
        }

        private int GetWidth()
        {
            int lines = _richTextBox.Lines.Length;
            int digits = lines.ToString().Length;
            return (int)(_richTextBox.Font.Size * digits) + 15;
        }

        public void AddLineNumbers()
        {
            Point ptTop = new Point(0, 0);
            int firstIndex = _richTextBox.GetCharIndexFromPosition(ptTop);
            int firstLine = _richTextBox.GetLineFromCharIndex(firstIndex);

            Point ptBottom = new Point(0, _richTextBox.ClientRectangle.Height);
            int lastIndex = _richTextBox.GetCharIndexFromPosition(ptBottom);
            int lastLine = _richTextBox.GetLineFromCharIndex(lastIndex);

            _lineNumberBox.Clear();
            _lineNumberBox.Width = GetWidth();

            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                _lineNumberBox.AppendText((i + 1).ToString() + Environment.NewLine);
            }
        }
    }
}
