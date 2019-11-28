namespace RemoveEmailsDuplicadoBasico
{
    partial class RED_Basico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RED_Basico));
            this.ckbTodos = new System.Windows.Forms.CheckBox();
            this.ButtonParar = new System.Windows.Forms.Button();
            this.LabelProgresso = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // ckbTodos
            // 
            this.ckbTodos.AutoSize = true;
            this.ckbTodos.Location = new System.Drawing.Point(380, 218);
            this.ckbTodos.Name = "ckbTodos";
            this.ckbTodos.Size = new System.Drawing.Size(56, 17);
            this.ckbTodos.TabIndex = 46;
            this.ckbTodos.Text = "Todos";
            this.ckbTodos.UseVisualStyleBackColor = true;
            this.ckbTodos.CheckedChanged += new System.EventHandler(this.ckbTodos_CheckedChanged);
            // 
            // ButtonParar
            // 
            this.ButtonParar.Location = new System.Drawing.Point(392, 83);
            this.ButtonParar.Name = "ButtonParar";
            this.ButtonParar.Size = new System.Drawing.Size(75, 23);
            this.ButtonParar.TabIndex = 45;
            this.ButtonParar.Text = "Parar";
            this.ButtonParar.UseVisualStyleBackColor = true;
            this.ButtonParar.Click += new System.EventHandler(this.ButtonParar_Click);
            // 
            // LabelProgresso
            // 
            this.LabelProgresso.AutoSize = true;
            this.LabelProgresso.Location = new System.Drawing.Point(206, 257);
            this.LabelProgresso.Name = "LabelProgresso";
            this.LabelProgresso.Size = new System.Drawing.Size(54, 13);
            this.LabelProgresso.TabIndex = 44;
            this.LabelProgresso.Text = "Progresso";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(206, 273);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 43;
            // 
            // LabelApagados
            // 
            this.LabelApagados.AutoSize = true;
            this.LabelApagados.Location = new System.Drawing.Point(126, 311);
            this.LabelApagados.Name = "LabelApagados";
            this.LabelApagados.Size = new System.Drawing.Size(13, 13);
            this.LabelApagados.TabIndex = 42;
            this.LabelApagados.Text = "0";
            // 
            // LabelProcessados
            // 
            this.LabelProcessados.AutoSize = true;
            this.LabelProcessados.Location = new System.Drawing.Point(126, 284);
            this.LabelProcessados.Name = "LabelProcessados";
            this.LabelProcessados.Size = new System.Drawing.Size(13, 13);
            this.LabelProcessados.TabIndex = 41;
            this.LabelProcessados.Text = "0";
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Location = new System.Drawing.Point(126, 257);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(13, 13);
            this.LabelTotal.TabIndex = 40;
            this.LabelTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Itens apagados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Itens processados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Total de itens:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Pastas na caixa selecionada";
            // 
            // ButtonProcessar
            // 
            this.ButtonProcessar.Location = new System.Drawing.Point(392, 37);
            this.ButtonProcessar.Name = "ButtonProcessar";
            this.ButtonProcessar.Size = new System.Drawing.Size(75, 23);
            this.ButtonProcessar.TabIndex = 35;
            this.ButtonProcessar.Text = "Processar";
            this.ButtonProcessar.UseVisualStyleBackColor = true;
            this.ButtonProcessar.Click += new System.EventHandler(this.ButtonProcessar_Click);
            // 
            // ListBoxCaixas
            // 
            this.ListBoxCaixas.FormattingEnabled = true;
            this.ListBoxCaixas.Location = new System.Drawing.Point(11, 37);
            this.ListBoxCaixas.Name = "ListBoxCaixas";
            this.ListBoxCaixas.Size = new System.Drawing.Size(159, 199);
            this.ListBoxCaixas.TabIndex = 34;
            this.ListBoxCaixas.SelectedIndexChanged += new System.EventHandler(this.ListBoxCaixas_SelectedIndexChanged);
            // 
            // CheckedListBoxPastas
            // 
            this.CheckedListBoxPastas.FormattingEnabled = true;
            this.CheckedListBoxPastas.Location = new System.Drawing.Point(206, 37);
            this.CheckedListBoxPastas.Name = "CheckedListBoxPastas";
            this.CheckedListBoxPastas.Size = new System.Drawing.Size(167, 199);
            this.CheckedListBoxPastas.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Caixas de Email";
            // 
            // RED_Basico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 354);
            this.Controls.Add(this.ckbTodos);
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
            this.Name = "RED_Basico";
            this.Text = "Remover E-mails Duplicados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RED_Basico_FormClosing);
            this.Load += new System.EventHandler(this.RED_Basico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbTodos;
        private System.Windows.Forms.Button ButtonParar;
        private System.Windows.Forms.Label LabelProgresso;
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
    }
}

