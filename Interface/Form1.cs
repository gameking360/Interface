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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class Form1 : Form
    {
        private NumberedBorder numberedBorder;
        public Form1()
        {
            InitializeComponent();
            // Cria o painel de numeração DENTRO do RichTextBox, colado à direita
            numberedBorder = new NumberedBorder(richTextBox1);
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

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
