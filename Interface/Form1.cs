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
            Clipboard.SetText(this.richTextBox1.SelectedText);
        }

        public void Recortar()
        {
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
