﻿namespace RSA_Operativos
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncrip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesen = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.btnEncrip = new System.Windows.Forms.Button();
            this.btnDesen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlano = new System.Windows.Forms.TextBox();
            this.progres = new System.Windows.Forms.ProgressBar();
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Paralelo";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(130, 25);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(56, 20);
            this.txtP.TabIndex = 7;
            this.txtP.TextChanged += new System.EventHandler(this.txtP_TextChanged);
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(216, 25);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(56, 20);
            this.txtQ.TabIndex = 8;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "P:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Q:";
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
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 507);
            this.Controls.Add(this.progres);
            this.Controls.Add(this.txtPlano);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDesen);
            this.Controls.Add(this.btnEncrip);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEncrip);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Name = "RSA";
            this.Text = "Cifrado RSA";
            this.Load += new System.EventHandler(this.RSA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesen;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Button btnEncrip;
        private System.Windows.Forms.Button btnDesen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlano;
        private System.Windows.Forms.ProgressBar progres;
    }
}

