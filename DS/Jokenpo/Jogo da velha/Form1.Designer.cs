namespace Jogo_da_velha
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbJogada = new System.Windows.Forms.ComboBox();
            this.btnJogar = new System.Windows.Forms.Button();
            this.lblVoce = new System.Windows.Forms.Label();
            this.lblBob = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblPlacar = new System.Windows.Forms.Label();
            this.Historico = new System.Windows.Forms.ListBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha sua jogada:";
            // 
            // cmbJogada
            // 
            this.cmbJogada.BackColor = System.Drawing.SystemColors.HotTrack;
            this.cmbJogada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJogada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJogada.FormattingEnabled = true;
            this.cmbJogada.Items.AddRange(new object[] {
            "Pedra",
            "Papel",
            "Tesoura"});
            this.cmbJogada.Location = new System.Drawing.Point(222, 91);
            this.cmbJogada.Name = "cmbJogada";
            this.cmbJogada.Size = new System.Drawing.Size(141, 21);
            this.cmbJogada.TabIndex = 1;
            // 
            // btnJogar
            // 
            this.btnJogar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnJogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.Location = new System.Drawing.Point(105, 143);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(141, 34);
            this.btnJogar.TabIndex = 2;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // lblVoce
            // 
            this.lblVoce.AutoSize = true;
            this.lblVoce.BackColor = System.Drawing.Color.Transparent;
            this.lblVoce.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblVoce.Location = new System.Drawing.Point(51, 230);
            this.lblVoce.Name = "lblVoce";
            this.lblVoce.Size = new System.Drawing.Size(65, 24);
            this.lblVoce.TabIndex = 3;
            this.lblVoce.Text = "Você:";
            // 
            // lblBob
            // 
            this.lblBob.AutoSize = true;
            this.lblBob.BackColor = System.Drawing.Color.Transparent;
            this.lblBob.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblBob.Location = new System.Drawing.Point(233, 230);
            this.lblBob.Name = "lblBob";
            this.lblBob.Size = new System.Drawing.Size(53, 24);
            this.lblBob.TabIndex = 4;
            this.lblBob.Text = "Bob:";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.Color.Transparent;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(128, 343);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(118, 25);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.Text = "Resultado";
            // 
            // lblPlacar
            // 
            this.lblPlacar.AutoSize = true;
            this.lblPlacar.BackColor = System.Drawing.Color.Transparent;
            this.lblPlacar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacar.Location = new System.Drawing.Point(537, 9);
            this.lblPlacar.Name = "lblPlacar";
            this.lblPlacar.Size = new System.Drawing.Size(154, 25);
            this.lblPlacar.TabIndex = 6;
            this.lblPlacar.Text = "Você:  | Bob: ";
            this.lblPlacar.Click += new System.EventHandler(this.label2_Click);
            // 
            // Historico
            // 
            this.Historico.FormattingEnabled = true;
            this.Historico.Location = new System.Drawing.Point(469, 48);
            this.Historico.Name = "Historico";
            this.Historico.Size = new System.Drawing.Size(300, 316);
            this.Historico.TabIndex = 7;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(469, 384);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(141, 36);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(628, 384);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(141, 36);
            this.btnReiniciar.TabIndex = 9;
            this.btnReiniciar.Text = "NOVO JOGO";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "VENÇA O BOB NO PEDRA, PAPEL OU TESOURA!!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jogo_da_velha.Properties.Resources.p;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.Historico);
            this.Controls.Add(this.lblPlacar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblBob);
            this.Controls.Add(this.lblVoce);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.cmbJogada);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbJogada;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Label lblVoce;
        private System.Windows.Forms.Label lblBob;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblPlacar;
        private System.Windows.Forms.ListBox Historico;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label label2;
    }
}

