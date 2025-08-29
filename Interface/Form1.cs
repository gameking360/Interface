using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface.Components;
using Interface.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class Form1 : Form
    {
        private NumberedBorder numberedBorder;
        private TecladoService tecladoService;
        private OpenFileDialog fileDialog;
        private string caminho;
        public Form1()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
            // Cria o painel de numeração DENTRO do RichTextBox, colado à direita
            numberedBorder = new NumberedBorder(richTextBox1);
            tecladoService = new TecladoService(richTextBox2,this, fileDialog);
            InitializeFunctions();
            caminho = "";
            // Adiciona handler para customizar o splitter
            this.splitContainer1.Paint += SplitContainer1_Paint;
        }

        private void SplitContainer1_Paint(object sender, PaintEventArgs e)
        {
            var sc = sender as SplitContainer;
            if (sc.Orientation == Orientation.Horizontal)
            {
                int splitterWidth = sc.SplitterWidth;
                int x = sc.SplitterRectangle.X;
                int y = sc.SplitterRectangle.Y;
                int width = sc.SplitterRectangle.Width;
                int height = sc.SplitterRectangle.Height;
                int centerX = x + width / 2;
                int centerY = y + height / 2;
                // Desenha pontos no centro do splitter
                for (int i = -2; i <= 2; i++)
                {
                    e.Graphics.FillEllipse(SystemBrushes.ControlDarkDark, centerX - 15 + i * 7, centerY - 3, 4, 4);
                }
            }
            else
            {
                int splitterHeight = sc.SplitterWidth;
                int x = sc.SplitterRectangle.X;
                int y = sc.SplitterRectangle.Y;
                int width = sc.SplitterRectangle.Width;
                int height = sc.SplitterRectangle.Height;
                int centerX = x + width / 2;
                int centerY = y + height / 2;
                for (int i = -2; i <= 2; i++)
                {
                    e.Graphics.FillEllipse(SystemBrushes.ControlDarkDark, centerX - 3, centerY - 15 + i * 7, 4, 4);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(e is KeyEventArgs chave)
            {
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeFunctions()
        {

            // Inicializa funções adicionais aqui
            this.KeyDown += this.tecladoService.OnKeyDown;
            this.tecladoService.OnClick(this.buttonCompilar);
            this.tecladoService.OnClick(this.buttonEquipe);
            this.tecladoService.OnClick(this.buttonNovo);
            this.tecladoService.OnClick(this.buttonCopiar);
            this.tecladoService.OnClick(this.buttonColar);
            this.tecladoService.OnClick(this.buttonRecortar);
            this.tecladoService.OnClick(this.button1);
            this.tecladoService.OnClick(this.buttonSalvar);
        }

        public void Limpar()
        {
            this.richTextBox1.Text = "";
            this.richTextBox2.Text = "";
            this.caminho = "";
            this.Status.Text = "";
        }

        public void Colar(string texto)
        {
            string textoAnterior = this.richTextBox1.Text;
            string nova = texto;

            int pos = this.richTextBox1.SelectionStart;
            this.richTextBox1.Text = textoAnterior.Insert(pos, nova);
            this.richTextBox1.Focus();
            this.richTextBox1.SelectionStart = pos + nova.Length; 

        }

        public void Copiar()
        {
            if (this.richTextBox1.Text == null || this.richTextBox1.SelectedText == "") {
                return; 
            }
            Clipboard.SetText(this.richTextBox1.SelectedText);
        }

        public void Recortar()
        {
            if (this.richTextBox1.Text == null || this.richTextBox1.SelectedText == "")
            {
                return;
            }
            string textoAnterior = this.richTextBox1.Text;
            string recortado = this.richTextBox1.SelectedText;
            int pos = this.richTextBox1.SelectionStart;
            this.richTextBox1.Text = textoAnterior.Remove(pos, recortado.Length);
            this.richTextBox1.Focus();
            this.richTextBox1.SelectionStart = pos;
            Clipboard.SetText(recortado);
        }

        public void PreencherEditor(string texto)
        {
            this.richTextBox1.Text = texto;
        }

        public void SetCaminho(string caminho)
        {
            this.caminho = caminho;
            this.Status.Text = this.caminho;
        }

        public string GetCaminho()
        {
            return this.caminho;
        }

        public string GetTexto()
        {
            return this.richTextBox1.Text.Trim();

        }

        public byte[] GetTextoBytes()
        {
            return Encoding.UTF8.GetBytes(this.richTextBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
