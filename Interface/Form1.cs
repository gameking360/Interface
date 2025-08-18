using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(e is KeyEventArgs chave)
            {
                Console.WriteLine(chave.KeyCode);
            }
        }

        private void entradaTecladoProgama(object sender, KeyEventArgs e)
        {
            // Aqui você pode adicionar lógica para lidar com eventos de teclado
            // Por exemplo, verificar se uma tecla específica foi pressionada
            if (e.KeyCode == Keys.Enter)
            {
                // Ação a ser executada quando a tecla Enter for pressionada
                int linha = int.Parse(this.richTextBox2.Text.Split('\n').Last());
                linha++;
                this.richTextBox2.AppendText("\n" + linha + "");

            }
            else
            {
                // Outras ações para outras teclas, se necessário
            }
        }
    }
}
