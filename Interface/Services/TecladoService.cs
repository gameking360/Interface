using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Services
{
    public class TecladoService
    {
        private Form1 formulario;
        private RichTextBox messages;
        private OpenFileDialog fileDialog;

        public TecladoService() { }
        // Implement keyboard handling methods here

        public TecladoService(RichTextBox mensagens, Form1 formulario, OpenFileDialog fileDialog)
        {
            this.messages = mensagens;
            this.formulario = formulario;
            this.fileDialog = fileDialog;
        }
        public void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F7)
            {
                this.Compilar();
            }
            else if (e.KeyCode == Keys.F1)
            {
                this.Equipe();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                this.Novo();
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                this.Abrir();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                this.Salvar();
            }
        }

        public void OnClick(System.Windows.Forms.Button btn)
        {
            switch (btn.Name)
            {
                case "buttonEquipe":
                    btn.Click += this.Equipe;
                    break;
                case "buttonCompilar":
                    btn.Click += this.Compilar;
                    break;
                case "buttonNovo":
                    btn.Click += this.Novo;
                    break;
                case "buttonCopiar":
                    btn.Click += (sender, e) => {
                        this.formulario.Copiar();
                    };
                    break;
                case "buttonColar":
                    btn.Click += (sender, e) => {
                        this.formulario.Colar(Clipboard.GetText());
                    };
                    break;
                case "buttonRecortar":
                    btn.Click += (sender, e) => {
                        this.formulario.Recortar();
                    };
                    break;
                case "button1":
                    btn.Click += this.Abrir;
                    break;
                case "buttonSalvar":
                    btn.Click += this.Salvar;
                    break;
            }
        }



        private void Compilar()
        {
            this.messages.Text = "compilação de programas ainda não foi implementada";
        }

        private void Compilar(Object sender, EventArgs e)
        {
            this.messages.Text = "compilação de programas ainda não foi implementada";
        }


        private void Novo(Object sender, EventArgs e)
        {
            this.formulario.Limpar();
        }

        private void Novo()
        {
            this.formulario.Limpar();
        }



        private void Equipe()
        {
            this.messages.Text = "Gabriel Dalmarco Labes\nJoão Pedro Erhardt";
        }

        private void Equipe(object sender, EventArgs e)
        {
            this.messages.Text = "Gabriel Dalmarco Labes\nJoão Pedro Erhardt";
        }

        private void Salvar()
        {
            this.SalvarService();
        }

        private void Salvar(object sender, EventArgs e)
        {
            this.SalvarService();
        }

        private void SalvarService()
        {
            if(this.formulario.GetCaminho() == "")
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter   = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*\"";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sv.FileName, this.formulario.GetTexto());
                    this.messages.Text = "";
                    this.formulario.SetCaminho(sv.FileName);
                }
            }
            else
            {
                this.messages.Text = "";
                File.WriteAllText(this.formulario.GetCaminho(), this.formulario.GetTexto(), Encoding.UTF8);
            }
        }

        private void Abrir()
        {
            this.AbrirService();
        }

        private void Abrir(object sender, EventArgs e)
        {
            this.AbrirService();
        }

        private void AbrirService()
        {
            this.fileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
            if (this.fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = this.fileDialog.FileName;
                if(!filePath.Equals(this.formulario.GetCaminho()))
                try
                {
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    this.formulario.PreencherEditor(fileContent);
                    this.messages.Text = "";
                    this.formulario.SetCaminho(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir o arquivo: " + ex.Message);
                }
            }
        }
    }
}
