namespace RSA_Operativos
{
    partial class RSA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.paralel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncrip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesen = new System.Windows.Forms.TextBox();
            this.btnEncrip = new System.Windows.Forms.Button();
            this.btnDesen = new System.Windows.Forms.Button();
            this.txtPlano = new System.Windows.Forms.TextBox();
            this.progres = new System.Windows.Forms.ProgressBar();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTiempo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texto a Encriptar";
            // 
            // paralel
            // 
            this.paralel.AutoSize = true;
            this.paralel.Location = new System.Drawing.Point(12, 27);
            this.paralel.Name = "paralel";
            this.paralel.Size = new System.Drawing.Size(64, 17);
            this.paralel.TabIndex = 2;
            this.paralel.Text = "Paralelo";
            this.paralel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Texto a Encriptado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEncrip
            // 
            this.txtEncrip.Location = new System.Drawing.Point(12, 198);
            this.txtEncrip.Multiline = true;
            this.txtEncrip.Name = "txtEncrip";
            this.txtEncrip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEncrip.Size = new System.Drawing.Size(675, 137);
            this.txtEncrip.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Texto a Desencriptado";
            // 
            // txtDesen
            // 
            this.txtDesen.Location = new System.Drawing.Point(12, 354);
            this.txtDesen.Multiline = true;
            this.txtDesen.Name = "txtDesen";
            this.txtDesen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesen.Size = new System.Drawing.Size(675, 119);
            this.txtDesen.TabIndex = 5;
            this.txtDesen.TextChanged += new System.EventHandler(this.txtDesen_TextChanged);
            // 
            // btnEncrip
            // 
            this.btnEncrip.Location = new System.Drawing.Point(531, 45);
            this.btnEncrip.Name = "btnEncrip";
            this.btnEncrip.Size = new System.Drawing.Size(75, 23);
            this.btnEncrip.TabIndex = 9;
            this.btnEncrip.Text = "Encriptar";
            this.btnEncrip.UseVisualStyleBackColor = true;
            this.btnEncrip.Click += new System.EventHandler(this.btnEncrip_Click);
            // 
            // btnDesen
            // 
            this.btnDesen.Location = new System.Drawing.Point(612, 45);
            this.btnDesen.Name = "btnDesen";
            this.btnDesen.Size = new System.Drawing.Size(75, 23);
            this.btnDesen.TabIndex = 10;
            this.btnDesen.Text = "Desencriptar";
            this.btnDesen.UseVisualStyleBackColor = true;
            this.btnDesen.Click += new System.EventHandler(this.btnDesen_Click);
            // 
            // txtPlano
            // 
            this.txtPlano.Location = new System.Drawing.Point(12, 74);
            this.txtPlano.Multiline = true;
            this.txtPlano.Name = "txtPlano";
            this.txtPlano.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPlano.Size = new System.Drawing.Size(675, 105);
            this.txtPlano.TabIndex = 13;
            // 
            // progres
            // 
            this.progres.Location = new System.Drawing.Point(12, 479);
            this.progres.Name = "progres";
            this.progres.Size = new System.Drawing.Size(675, 23);
            this.progres.TabIndex = 14;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(156, 27);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(177, 20);
            this.txtPass.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contraseña";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click_1);
            // 
            // txtTiempo
            // 
            this.txtTiempo.AutoSize = true;
            this.txtTiempo.Location = new System.Drawing.Point(339, 28);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(48, 13);
            this.txtTiempo.TabIndex = 18;
            this.txtTiempo.Text = "Tiempo: ";
            this.txtTiempo.Click += new System.EventHandler(this.label5_Click);
            // 
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 507);
            this.Controls.Add(this.txtTiempo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.progres);
            this.Controls.Add(this.txtPlano);
            this.Controls.Add(this.btnDesen);
            this.Controls.Add(this.btnEncrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEncrip);
            this.Controls.Add(this.paralel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RSA";
            this.Text = "Cifrado RC4";
            this.Load += new System.EventHandler(this.RSA_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox paralel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesen;
        private System.Windows.Forms.Button btnEncrip;
        private System.Windows.Forms.Button btnDesen;
        private System.Windows.Forms.TextBox txtPlano;
        private System.Windows.Forms.ProgressBar progres;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.Label txtTiempo;
    }
}

