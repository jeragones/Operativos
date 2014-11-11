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
            this.cbIron = new System.Windows.Forms.CheckBox();
            this.cbRabbit = new System.Windows.Forms.CheckBox();
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
            this.cant.Size = new System.Drawing.Size(160, 20);
            this.cant.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbIron
            // 
            this.cbIron.AutoSize = true;
            this.cbIron.Location = new System.Drawing.Point(15, 51);
            this.cbIron.Name = "cbIron";
            this.cbIron.Size = new System.Drawing.Size(61, 17);
            this.cbIron.TabIndex = 8;
            this.cbIron.Text = "IronMQ";
            this.cbIron.UseVisualStyleBackColor = true;
            // 
            // cbRabbit
            // 
            this.cbRabbit.AutoSize = true;
            this.cbRabbit.Location = new System.Drawing.Point(82, 51);
            this.cbRabbit.Name = "cbRabbit";
            this.cbRabbit.Size = new System.Drawing.Size(74, 17);
            this.cbRabbit.TabIndex = 9;
            this.cbRabbit.Text = "RabbitMQ";
            this.cbRabbit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(184, 112);
            this.Controls.Add(this.cbRabbit);
            this.Controls.Add(this.cbIron);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cant);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "App 1";
            ((System.ComponentModel.ISupportInitialize)(this.cant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cant;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbIron;
        private System.Windows.Forms.CheckBox cbRabbit;
    }
}

