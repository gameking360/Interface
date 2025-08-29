namespace Interface
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonEquipe = new System.Windows.Forms.Button();
            this.buttonCompilar = new System.Windows.Forms.Button();
            this.buttonRecortar = new System.Windows.Forms.Button();
            this.buttonColar = new System.Windows.Forms.Button();
            this.buttonCopiar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonNovo = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(1464, 315);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // buttonEquipe
            // 
            this.buttonEquipe.Image = global::Interface.Properties.Resources.Equipe;
            this.buttonEquipe.Location = new System.Drawing.Point(978, 12);
            this.buttonEquipe.Name = "buttonEquipe";
            this.buttonEquipe.Size = new System.Drawing.Size(132, 70);
            this.buttonEquipe.TabIndex = 10;
            this.buttonEquipe.Text = "Equipe [F1]";
            this.buttonEquipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEquipe.UseVisualStyleBackColor = true;
            // 
            // buttonCompilar
            // 
            this.buttonCompilar.Image = global::Interface.Properties.Resources.Compilar;
            this.buttonCompilar.Location = new System.Drawing.Point(840, 12);
            this.buttonCompilar.Name = "buttonCompilar";
            this.buttonCompilar.Size = new System.Drawing.Size(132, 70);
            this.buttonCompilar.TabIndex = 9;
            this.buttonCompilar.Text = "Compilar [F7]";
            this.buttonCompilar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCompilar.UseVisualStyleBackColor = true;
            // 
            // buttonRecortar
            // 
            this.buttonRecortar.Image = global::Interface.Properties.Resources.Recortar;
            this.buttonRecortar.Location = new System.Drawing.Point(702, 12);
            this.buttonRecortar.Name = "buttonRecortar";
            this.buttonRecortar.Size = new System.Drawing.Size(132, 70);
            this.buttonRecortar.TabIndex = 8;
            this.buttonRecortar.Text = "Recortar [ctrl+x]";
            this.buttonRecortar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonRecortar.UseVisualStyleBackColor = true;
            // 
            // buttonColar
            // 
            this.buttonColar.Image = global::Interface.Properties.Resources.Colar;
            this.buttonColar.Location = new System.Drawing.Point(564, 12);
            this.buttonColar.Name = "buttonColar";
            this.buttonColar.Size = new System.Drawing.Size(132, 70);
            this.buttonColar.TabIndex = 7;
            this.buttonColar.Text = "Colar [ctrl+v]";
            this.buttonColar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonColar.UseVisualStyleBackColor = true;
            // 
            // buttonCopiar
            // 
            this.buttonCopiar.Image = global::Interface.Properties.Resources.Copiar;
            this.buttonCopiar.Location = new System.Drawing.Point(426, 12);
            this.buttonCopiar.Name = "buttonCopiar";
            this.buttonCopiar.Size = new System.Drawing.Size(132, 70);
            this.buttonCopiar.TabIndex = 6;
            this.buttonCopiar.Text = "Copiar [ctrl+c]";
            this.buttonCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCopiar.UseVisualStyleBackColor = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Image = global::Interface.Properties.Resources.Salvar;
            this.buttonSalvar.Location = new System.Drawing.Point(288, 12);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(132, 70);
            this.buttonSalvar.TabIndex = 5;
            this.buttonSalvar.Text = "Salvar [ctrl+s]";
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSalvar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::Interface.Properties.Resources.Abrir;
            this.button1.Location = new System.Drawing.Point(150, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 70);
            this.button1.TabIndex = 4;
            this.button1.Text = "Abrir [ctrl+o]";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonNovo
            // 
            this.buttonNovo.Image = global::Interface.Properties.Resources.Novo;
            this.buttonNovo.Location = new System.Drawing.Point(12, 12);
            this.buttonNovo.Name = "buttonNovo";
            this.buttonNovo.Size = new System.Drawing.Size(132, 70);
            this.buttonNovo.TabIndex = 3;
            this.buttonNovo.Text = "Novo [ctrl+n]";
            this.buttonNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonNovo.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox2.Size = new System.Drawing.Size(1464, 263);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 93);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // Panel1
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // Panel2
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1464, 590);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 20;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(12, 686);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 16);
            this.Status.TabIndex = 13;
            this.Status.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonEquipe);
            this.Controls.Add(this.buttonCompilar);
            this.Controls.Add(this.buttonRecortar);
            this.Controls.Add(this.buttonColar);
            this.Controls.Add(this.buttonCopiar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonNovo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonNovo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCopiar;
        private System.Windows.Forms.Button buttonColar;
        private System.Windows.Forms.Button buttonRecortar;
        private System.Windows.Forms.Button buttonCompilar;
        private System.Windows.Forms.Button buttonEquipe;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label Status;
    }
}

