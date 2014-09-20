namespace Multicore
{
    partial class frmMulticore
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
            this.btnAnalisis = new System.Windows.Forms.Button();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.labelresultado = new System.Windows.Forms.Label();
            this.txtPalabrasComunes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCaracteres = new System.Windows.Forms.Label();
            this.lblPalabras = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkParallel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Location = new System.Drawing.Point(493, 126);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalisis.TabIndex = 2;
            this.btnAnalisis.Text = "Analizar";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAcciones.Controls.Add(this.labelresultado);
            this.pnlAcciones.Controls.Add(this.btnAnalisis);
            this.pnlAcciones.Controls.Add(this.txtPalabrasComunes);
            this.pnlAcciones.Controls.Add(this.label4);
            this.pnlAcciones.Controls.Add(this.lblCaracteres);
            this.pnlAcciones.Controls.Add(this.lblPalabras);
            this.pnlAcciones.Controls.Add(this.label3);
            this.pnlAcciones.Controls.Add(this.checkParallel);
            this.pnlAcciones.Controls.Add(this.label2);
            this.pnlAcciones.Controls.Add(this.lblIdioma);
            this.pnlAcciones.Controls.Add(this.label1);
            this.pnlAcciones.Location = new System.Drawing.Point(12, 12);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(573, 154);
            this.pnlAcciones.TabIndex = 0;
            // 
            // labelresultado
            // 
            this.labelresultado.AutoSize = true;
            this.labelresultado.Location = new System.Drawing.Point(87, 131);
            this.labelresultado.Name = "labelresultado";
            this.labelresultado.Size = new System.Drawing.Size(0, 13);
            this.labelresultado.TabIndex = 11;
            // 
            // txtPalabrasComunes
            // 
            this.txtPalabrasComunes.BackColor = System.Drawing.SystemColors.Control;
            this.txtPalabrasComunes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPalabrasComunes.Location = new System.Drawing.Point(145, 87);
            this.txtPalabrasComunes.Multiline = true;
            this.txtPalabrasComunes.Name = "txtPalabrasComunes";
            this.txtPalabrasComunes.Size = new System.Drawing.Size(412, 66);
            this.txtPalabrasComunes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Palabras comunes:";
            // 
            // lblCaracteres
            // 
            this.lblCaracteres.AutoSize = true;
            this.lblCaracteres.Location = new System.Drawing.Point(142, 62);
            this.lblCaracteres.Name = "lblCaracteres";
            this.lblCaracteres.Size = new System.Drawing.Size(31, 13);
            this.lblCaracteres.TabIndex = 5;
            this.lblCaracteres.Text = "        \r\n";
            // 
            // lblPalabras
            // 
            this.lblPalabras.AutoSize = true;
            this.lblPalabras.Location = new System.Drawing.Point(142, 36);
            this.lblPalabras.Name = "lblPalabras";
            this.lblPalabras.Size = new System.Drawing.Size(31, 13);
            this.lblPalabras.TabIndex = 4;
            this.lblPalabras.Text = "        \r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cantidad de caracteres:";
            // 
            // checkParallel
            // 
            this.checkParallel.AutoSize = true;
            this.checkParallel.Location = new System.Drawing.Point(16, 130);
            this.checkParallel.Name = "checkParallel";
            this.checkParallel.Size = new System.Drawing.Size(60, 17);
            this.checkParallel.TabIndex = 10;
            this.checkParallel.Text = "Parallel";
            this.checkParallel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de palabras:";
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(142, 11);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(31, 13);
            this.lblIdioma.TabIndex = 1;
            this.lblIdioma.Text = "        \r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Idioma:";
            // 
            // frmMulticore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 180);
            this.Controls.Add(this.pnlAcciones);
            this.Name = "frmMulticore";
            this.Text = "Análisis de Texto";
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAnalisis;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.TextBox txtPalabrasComunes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCaracteres;
        private System.Windows.Forms.Label lblPalabras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkParallel;
        private System.Windows.Forms.Label labelresultado;
    }
}

