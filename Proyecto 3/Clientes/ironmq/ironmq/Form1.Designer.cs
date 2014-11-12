namespace ironmq
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.cant = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.iron = new System.Windows.Forms.RadioButton();
            this.rabbit = new System.Windows.Forms.RadioButton();
            this.terminator = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.cant)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad de Mensajes";
            // 
            // cant
            // 
            this.cant.Location = new System.Drawing.Point(12, 25);
            this.cant.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.cant.Name = "cant";
            this.cant.Size = new System.Drawing.Size(233, 20);
            this.cant.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iron
            // 
            this.iron.AutoSize = true;
            this.iron.Location = new System.Drawing.Point(12, 51);
            this.iron.Name = "iron";
            this.iron.Size = new System.Drawing.Size(60, 17);
            this.iron.TabIndex = 11;
            this.iron.TabStop = true;
            this.iron.Text = "IronMQ";
            this.iron.UseVisualStyleBackColor = true;
            // 
            // rabbit
            // 
            this.rabbit.AutoSize = true;
            this.rabbit.Location = new System.Drawing.Point(78, 51);
            this.rabbit.Name = "rabbit";
            this.rabbit.Size = new System.Drawing.Size(73, 17);
            this.rabbit.TabIndex = 12;
            this.rabbit.TabStop = true;
            this.rabbit.Text = "RabbitMQ";
            this.rabbit.UseVisualStyleBackColor = true;
            // 
            // terminator
            // 
            this.terminator.AutoSize = true;
            this.terminator.Location = new System.Drawing.Point(157, 51);
            this.terminator.Name = "terminator";
            this.terminator.Size = new System.Drawing.Size(92, 17);
            this.terminator.TabIndex = 13;
            this.terminator.TabStop = true;
            this.terminator.Text = "TerminatorMQ";
            this.terminator.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(255, 109);
            this.Controls.Add(this.terminator);
            this.Controls.Add(this.rabbit);
            this.Controls.Add(this.iron);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cant);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "App 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cant;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton iron;
        private System.Windows.Forms.RadioButton rabbit;
        private System.Windows.Forms.RadioButton terminator;
    }
}

