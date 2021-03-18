namespace RemoveEmailsDuplicados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonParar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LabelApagados = new System.Windows.Forms.Label();
            this.LabelProcessados = new System.Windows.Forms.Label();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonProcessar = new System.Windows.Forms.Button();
            this.ListBoxCaixas = new System.Windows.Forms.ListBox();
            this.CheckedListBoxPastas = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelComecarEm = new System.Windows.Forms.Label();
            this.NumeroComeco = new System.Windows.Forms.NumericUpDown();
            this.ckbTodos = new System.Windows.Forms.CheckBox();
            this.emailRemoverTxt = new System.Windows.Forms.TextBox();
            this.ButtonBlacklist = new System.Windows.Forms.Button();
            this.DialogListaNegra = new System.Windows.Forms.OpenFileDialog();
            this.BtnResetBlacklist = new System.Windows.Forms.Button();
            this.LabelProgresso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroComeco)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonParar
            // 
            this.ButtonParar.Location = new System.Drawing.Point(392, 80);
            this.ButtonParar.Name = "ButtonParar";
            this.ButtonParar.Size = new System.Drawing.Size(75, 23);
            this.ButtonParar.TabIndex = 28;
            this.ButtonParar.Text = "Parar";
            this.ButtonParar.UseVisualStyleBackColor = true;
            this.ButtonParar.Click += new System.EventHandler(this.ButtonParar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(202, 354);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 26;
            // 
            // LabelApagados
            // 
            this.LabelApagados.AutoSize = true;
            this.LabelApagados.Location = new System.Drawing.Point(122, 392);
            this.LabelApagados.Name = "LabelApagados";
            this.LabelApagados.Size = new System.Drawing.Size(13, 13);
            this.LabelApagados.TabIndex = 25;
            this.LabelApagados.Text = "0";
            // 
            // LabelProcessados
            // 
            this.LabelProcessados.AutoSize = true;
            this.LabelProcessados.Location = new System.Drawing.Point(122, 365);
            this.LabelProcessados.Name = "LabelProcessados";
            this.LabelProcessados.Size = new System.Drawing.Size(13, 13);
            this.LabelProcessados.TabIndex = 24;
            this.LabelProcessados.Text = "0";
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Location = new System.Drawing.Point(122, 338);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(13, 13);
            this.LabelTotal.TabIndex = 23;
            this.LabelTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Itens apagados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Itens processados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Total de itens:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Pastas na caixa selecionada";
            // 
            // ButtonProcessar
            // 
            this.ButtonProcessar.Location = new System.Drawing.Point(392, 37);
            this.ButtonProcessar.Name = "ButtonProcessar";
            this.ButtonProcessar.Size = new System.Drawing.Size(75, 23);
            this.ButtonProcessar.TabIndex = 18;
            this.ButtonProcessar.Text = "Processar";
            this.ButtonProcessar.UseVisualStyleBackColor = true;
            this.ButtonProcessar.Click += new System.EventHandler(this.ButtonProcessar_Click);
            // 
            // ListBoxCaixas
            // 
            this.ListBoxCaixas.FormattingEnabled = true;
            this.ListBoxCaixas.Location = new System.Drawing.Point(11, 37);
            this.ListBoxCaixas.Name = "ListBoxCaixas";
            this.ListBoxCaixas.Size = new System.Drawing.Size(159, 290);
            this.ListBoxCaixas.TabIndex = 17;
            this.ListBoxCaixas.SelectedIndexChanged += new System.EventHandler(this.ListBoxCaixas_SelectedIndexChanged);
            // 
            // CheckedListBoxPastas
            // 
            this.CheckedListBoxPastas.FormattingEnabled = true;
            this.CheckedListBoxPastas.Location = new System.Drawing.Point(206, 37);
            this.CheckedListBoxPastas.Name = "CheckedListBoxPastas";
            this.CheckedListBoxPastas.Size = new System.Drawing.Size(167, 289);
            this.CheckedListBoxPastas.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Caixas de Email";
            // 
            // labelComecarEm
            // 
            this.labelComecarEm.AutoSize = true;
            this.labelComecarEm.Location = new System.Drawing.Point(391, 257);
            this.labelComecarEm.Name = "labelComecarEm";
            this.labelComecarEm.Size = new System.Drawing.Size(66, 13);
            this.labelComecarEm.TabIndex = 29;
            this.labelComecarEm.Text = "Começar em";
            // 
            // NumeroComeco
            // 
            this.NumeroComeco.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumeroComeco.Location = new System.Drawing.Point(392, 274);
            this.NumeroComeco.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumeroComeco.Name = "NumeroComeco";
            this.NumeroComeco.Size = new System.Drawing.Size(78, 20);
            this.NumeroComeco.TabIndex = 30;
            // 
            // ckbTodos
            // 
            this.ckbTodos.AutoSize = true;
            this.ckbTodos.Location = new System.Drawing.Point(379, 309);
            this.ckbTodos.Name = "ckbTodos";
            this.ckbTodos.Size = new System.Drawing.Size(56, 17);
            this.ckbTodos.TabIndex = 31;
            this.ckbTodos.Text = "Todos";
            this.ckbTodos.UseVisualStyleBackColor = true;
            this.ckbTodos.CheckedChanged += new System.EventHandler(this.ckbTodos_CheckedChanged);
            // 
            // emailRemoverTxt
            // 
            this.emailRemoverTxt.Location = new System.Drawing.Point(262, 386);
            this.emailRemoverTxt.Name = "emailRemoverTxt";
            this.emailRemoverTxt.Size = new System.Drawing.Size(201, 20);
            this.emailRemoverTxt.TabIndex = 32;
            // 
            // ButtonBlacklist
            // 
            this.ButtonBlacklist.Location = new System.Drawing.Point(392, 147);
            this.ButtonBlacklist.Name = "ButtonBlacklist";
            this.ButtonBlacklist.Size = new System.Drawing.Size(75, 35);
            this.ButtonBlacklist.TabIndex = 33;
            this.ButtonBlacklist.Text = "Importar Blacklist";
            this.ButtonBlacklist.UseVisualStyleBackColor = true;
            this.ButtonBlacklist.Click += new System.EventHandler(this.ButtonBlacklist_Click);
            // 
            // DialogListaNegra
            // 
            this.DialogListaNegra.FileName = "ListaNegraEmails.txt";
            // 
            // BtnResetBlacklist
            // 
            this.BtnResetBlacklist.Location = new System.Drawing.Point(392, 188);
            this.BtnResetBlacklist.Name = "BtnResetBlacklist";
            this.BtnResetBlacklist.Size = new System.Drawing.Size(75, 35);
            this.BtnResetBlacklist.TabIndex = 34;
            this.BtnResetBlacklist.Text = "Limpar blacklist";
            this.BtnResetBlacklist.UseVisualStyleBackColor = true;
            this.BtnResetBlacklist.Click += new System.EventHandler(this.BtnResetBlacklist_Click);
            // 
            // LabelProgresso
            // 
            this.LabelProgresso.AutoSize = true;
            this.LabelProgresso.Location = new System.Drawing.Point(202, 338);
            this.LabelProgresso.Name = "LabelProgresso";
            this.LabelProgresso.Size = new System.Drawing.Size(54, 13);
            this.LabelProgresso.TabIndex = 27;
            this.LabelProgresso.Text = "Progresso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Apagar de:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 414);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnResetBlacklist);
            this.Controls.Add(this.ButtonBlacklist);
            this.Controls.Add(this.emailRemoverTxt);
            this.Controls.Add(this.ckbTodos);
            this.Controls.Add(this.NumeroComeco);
            this.Controls.Add(this.labelComecarEm);
            this.Controls.Add(this.ButtonParar);
            this.Controls.Add(this.LabelProgresso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LabelApagados);
            this.Controls.Add(this.LabelProcessados);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonProcessar);
            this.Controls.Add(this.ListBoxCaixas);
            this.Controls.Add(this.CheckedListBoxPastas);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Remover E-mails Duplicados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumeroComeco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonParar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LabelApagados;
        private System.Windows.Forms.Label LabelProcessados;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonProcessar;
        private System.Windows.Forms.ListBox ListBoxCaixas;
        private System.Windows.Forms.CheckedListBox CheckedListBoxPastas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelComecarEm;
        private System.Windows.Forms.NumericUpDown NumeroComeco;
        private System.Windows.Forms.CheckBox ckbTodos;
        private System.Windows.Forms.TextBox emailRemoverTxt;
        private System.Windows.Forms.Button ButtonBlacklist;
        private System.Windows.Forms.OpenFileDialog DialogListaNegra;
        private System.Windows.Forms.Button BtnResetBlacklist;
        private System.Windows.Forms.Label LabelProgresso;
        private System.Windows.Forms.Label label6;
    }
}

