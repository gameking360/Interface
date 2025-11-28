using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface.Lexico;

namespace Interface.Services
{
    public class TecladoService
    {
        private Form1 formulario;
        private RichTextBox messages;
        private OpenFileDialog fileDialog;

        public TecladoService() { }

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
            this.messages.Text = "";
            Lexico.Lexico lexico = new Lexico.Lexico();
            Sintatico sintatico = new Sintatico();
            Semantico semantico = new Semantico();
            
            try
            {
                string texto = this.formulario.GetTexto();
                lexico.setInput(texto);
                //Token t = null;
                //StringBuilder message = new StringBuilder();
               /// message.AppendLine("Linha         Classe                                                    Lexema");
               // while ((t = lexico.nextToken()) != null)
              //  {
                //    int tokenLine = linha + texto.Substring(0, t.getPosition()).Count(c => c == '\n');
                 //   String classe = new CompiladorServices().GetClassePorExtenso(t.getId());
                 //   message.AppendLine(tokenLine  +"         " + "          " +  classe + "                                 " + t.getLexeme());
               // }
               // message.AppendLine("\n      programa compilado com sucesso");
               // this.messages.Text = message.ToString();
               sintatico.Parse(lexico,semantico);
                this.GerarArquivo(semantico.getConteudo());
                this.messages.Text = "Programa compilado com sucesso!";
            }
            
            catch (LexicalError e)
            {
                this.messages.AppendText("Linha: " + CompiladorServices.GetLinha(this.formulario.GetTexto(),e.getPosition()) + ": " + e + " " + this.formulario.GetTexto()[e.getPosition()]);
            }
            catch(SyntaticError ex)
            {

                this.messages.AppendText($"Linha: {CompiladorServices.GetLinha(this.formulario.GetTexto(),ex.getPosition())} {ex}");
                // e.getMessage() são os símbolos esperados
                // e.getMessage() - retorna a mensagem de erro de PARSER_ERROR (ver ParserConstants.java)
                // necessário adaptar conforme o enunciado da parte 3

            }
            catch (SemanticError ex)
            {
                this.messages.AppendText($"Linha: {CompiladorServices.GetLinha(this.formulario.GetTexto(), ex.getPosition())} {ex}");
            }
        }

        private void Compilar(Object sender, EventArgs e)
        {
            this.Compilar();
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

        private  void GerarArquivo(string conteudo)
        {
            string caminhoAtual = this.formulario.GetCaminho();
            if (caminhoAtual == "")
            {
                this.SalvarService();
                caminhoAtual = this.formulario.GetCaminho();
            }

            caminhoAtual = caminhoAtual.Substring(0, caminhoAtual.LastIndexOf('.')) + ".il";

            File.WriteAllText(caminhoAtual, conteudo);

        }
    }
}
