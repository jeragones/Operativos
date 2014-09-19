namespace Sort_Methods
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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDesQuick = new System.Windows.Forms.RadioButton();
            this.rdbAscQuick = new System.Windows.Forms.RadioButton();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDesMerge = new System.Windows.Forms.RadioButton();
            this.rdbAscMerge = new System.Windows.Forms.RadioButton();
            this.btnMergeSort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbQuickParallel = new System.Windows.Forms.RadioButton();
            this.rdbQuickSecuential = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbMergeParallel = new System.Windows.Forms.RadioButton();
            this.rdbMergeSecuential = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblQuickTime = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblMergeTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(18, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(230, 45);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Cargar archivos";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnQuickSort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(18, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 189);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDesQuick);
            this.groupBox1.Controls.Add(this.rdbAscQuick);
            this.groupBox1.Location = new System.Drawing.Point(8, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden";
            // 
            // rdbDesQuick
            // 
            this.rdbDesQuick.AutoSize = true;
            this.rdbDesQuick.Location = new System.Drawing.Point(6, 42);
            this.rdbDesQuick.Name = "rdbDesQuick";
            this.rdbDesQuick.Size = new System.Drawing.Size(89, 17);
            this.rdbDesQuick.TabIndex = 5;
            this.rdbDesQuick.TabStop = true;
            this.rdbDesQuick.Text = "Descendente";
            this.rdbDesQuick.UseVisualStyleBackColor = true;
            // 
            // rdbAscQuick
            // 
            this.rdbAscQuick.AutoSize = true;
            this.rdbAscQuick.Location = new System.Drawing.Point(6, 19);
            this.rdbAscQuick.Name = "rdbAscQuick";
            this.rdbAscQuick.Size = new System.Drawing.Size(82, 17);
            this.rdbAscQuick.TabIndex = 3;
            this.rdbAscQuick.TabStop = true;
            this.rdbAscQuick.Text = "Ascendente";
            this.rdbAscQuick.UseVisualStyleBackColor = true;
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Location = new System.Drawing.Point(60, 7);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(159, 23);
            this.btnQuickSort.TabIndex = 3;
            this.btnQuickSort.Text = "QuickSort";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Método:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btnMergeSort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(18, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 189);
            this.panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDesMerge);
            this.groupBox2.Controls.Add(this.rdbAscMerge);
            this.groupBox2.Location = new System.Drawing.Point(8, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 66);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orden";
            // 
            // rdbDesMerge
            // 
            this.rdbDesMerge.AutoSize = true;
            this.rdbDesMerge.Location = new System.Drawing.Point(9, 42);
            this.rdbDesMerge.Name = "rdbDesMerge";
            this.rdbDesMerge.Size = new System.Drawing.Size(89, 17);
            this.rdbDesMerge.TabIndex = 8;
            this.rdbDesMerge.TabStop = true;
            this.rdbDesMerge.Text = "Descendente";
            this.rdbDesMerge.UseVisualStyleBackColor = true;
            // 
            // rdbAscMerge
            // 
            this.rdbAscMerge.AutoSize = true;
            this.rdbAscMerge.Location = new System.Drawing.Point(9, 19);
            this.rdbAscMerge.Name = "rdbAscMerge";
            this.rdbAscMerge.Size = new System.Drawing.Size(82, 17);
            this.rdbAscMerge.TabIndex = 7;
            this.rdbAscMerge.TabStop = true;
            this.rdbAscMerge.Text = "Ascendente";
            this.rdbAscMerge.UseVisualStyleBackColor = true;
            // 
            // btnMergeSort
            // 
            this.btnMergeSort.Location = new System.Drawing.Point(60, 8);
            this.btnMergeSort.Name = "btnMergeSort";
            this.btnMergeSort.Size = new System.Drawing.Size(159, 23);
            this.btnMergeSort.TabIndex = 5;
            this.btnMergeSort.Text = "MergeSort";
            this.btnMergeSort.UseVisualStyleBackColor = true;
            this.btnMergeSort.Click += new System.EventHandler(this.btnMergeSort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Método:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbQuickParallel);
            this.groupBox3.Controls.Add(this.rdbQuickSecuential);
            this.groupBox3.Location = new System.Drawing.Point(118, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 66);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ejecución";
            // 
            // rdbQuickParallel
            // 
            this.rdbQuickParallel.AutoSize = true;
            this.rdbQuickParallel.Location = new System.Drawing.Point(6, 42);
            this.rdbQuickParallel.Name = "rdbQuickParallel";
            this.rdbQuickParallel.Size = new System.Drawing.Size(83, 17);
            this.rdbQuickParallel.TabIndex = 7;
            this.rdbQuickParallel.TabStop = true;
            this.rdbQuickParallel.Text = "Concurrente";
            this.rdbQuickParallel.UseVisualStyleBackColor = true;
            // 
            // rdbQuickSecuential
            // 
            this.rdbQuickSecuential.AutoSize = true;
            this.rdbQuickSecuential.Location = new System.Drawing.Point(6, 19);
            this.rdbQuickSecuential.Name = "rdbQuickSecuential";
            this.rdbQuickSecuential.Size = new System.Drawing.Size(78, 17);
            this.rdbQuickSecuential.TabIndex = 6;
            this.rdbQuickSecuential.TabStop = true;
            this.rdbQuickSecuential.Text = "Secuencial";
            this.rdbQuickSecuential.UseVisualStyleBackColor = true;
            this.rdbQuickSecuential.CheckedChanged += new System.EventHandler(this.rdbQuickSecuential_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbMergeParallel);
            this.groupBox4.Controls.Add(this.rdbMergeSecuential);
            this.groupBox4.Location = new System.Drawing.Point(118, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(101, 66);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ejecución";
            // 
            // rdbMergeParallel
            // 
            this.rdbMergeParallel.AutoSize = true;
            this.rdbMergeParallel.Location = new System.Drawing.Point(6, 42);
            this.rdbMergeParallel.Name = "rdbMergeParallel";
            this.rdbMergeParallel.Size = new System.Drawing.Size(83, 17);
            this.rdbMergeParallel.TabIndex = 7;
            this.rdbMergeParallel.TabStop = true;
            this.rdbMergeParallel.Text = "Concurrente";
            this.rdbMergeParallel.UseVisualStyleBackColor = true;
            // 
            // rdbMergeSecuential
            // 
            this.rdbMergeSecuential.AutoSize = true;
            this.rdbMergeSecuential.Location = new System.Drawing.Point(6, 19);
            this.rdbMergeSecuential.Name = "rdbMergeSecuential";
            this.rdbMergeSecuential.Size = new System.Drawing.Size(78, 17);
            this.rdbMergeSecuential.TabIndex = 6;
            this.rdbMergeSecuential.TabStop = true;
            this.rdbMergeSecuential.Text = "Secuencial";
            this.rdbMergeSecuential.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblQuickTime);
            this.groupBox5.Location = new System.Drawing.Point(8, 108);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(211, 67);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tiempo de ejecución";
            // 
            // lblQuickTime
            // 
            this.lblQuickTime.AutoSize = true;
            this.lblQuickTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickTime.Location = new System.Drawing.Point(6, 27);
            this.lblQuickTime.Name = "lblQuickTime";
            this.lblQuickTime.Size = new System.Drawing.Size(163, 25);
            this.lblQuickTime.TabIndex = 3;
            this.lblQuickTime.Text = "00:00:00:0000";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblMergeTime);
            this.groupBox6.Location = new System.Drawing.Point(8, 109);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 67);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tiempo de ejecución";
            // 
            // lblMergeTime
            // 
            this.lblMergeTime.AutoSize = true;
            this.lblMergeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMergeTime.Location = new System.Drawing.Point(6, 28);
            this.lblMergeTime.Name = "lblMergeTime";
            this.lblMergeTime.Size = new System.Drawing.Size(163, 25);
            this.lblMergeTime.TabIndex = 3;
            this.lblMergeTime.Text = "00:00:00:0000";
            this.lblMergeTime.Click += new System.EventHandler(this.lblMergeTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "Métodos de ordenamiento";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbDesQuick;
        private System.Windows.Forms.RadioButton rdbAscQuick;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbDesMerge;
        private System.Windows.Forms.RadioButton rdbAscMerge;
        private System.Windows.Forms.Button btnMergeSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbQuickParallel;
        private System.Windows.Forms.RadioButton rdbQuickSecuential;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblQuickTime;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblMergeTime;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbMergeParallel;
        private System.Windows.Forms.RadioButton rdbMergeSecuential;


    }
}

