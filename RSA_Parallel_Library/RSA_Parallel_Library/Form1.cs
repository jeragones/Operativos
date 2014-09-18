using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using IntXLib;

namespace RSA_Parallel_Library
{
    public partial class Form1 : Form
    {

        RSA rsa = new RSA();

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string texto = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos txt|*.txt";
            openFileDialog.FileName = "Seleccione un archivo";
            openFileDialog.Title = "Seleccione un archivo";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.FileName = mensaje;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mensaje = openFileDialog.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(mensaje, System.Text.Encoding.Default);
                texto = sr.ReadToEnd();
            }
            txtPlano.Text = texto;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdecrypt.Text = "";
            txtencrypt.Text = "";
            int p = Convert.ToInt32(txtP.Text);
            int q = Convert.ToInt32(txtQ.Text);
            var timer = Stopwatch.StartNew();
            rsa.publicKey(p, q);
            if (parallel.Checked)
            {
                txtencrypt.Text = rsa.EncrRSAParalelo(txtPlano.Text);
                
            }
            else
            {
                txtencrypt.Text = rsa.EncrRSASecuencial(txtPlano.Text);
            }
            timer.Stop();
            time.Text = "Tiempo: "+Convert.ToString(timer.Elapsed);
            
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            txtdecrypt.Text = "";
            int p = Convert.ToInt32(txtP.Text);
            int q = Convert.ToInt32(txtQ.Text);
            var timer = Stopwatch.StartNew();
            rsa.privateKey(p, q);
            if (parallel.Checked)
            {
                txtdecrypt.Text = rsa.DesenRSAParalelo(txtencrypt.Text);

            }
            else
            {
                txtdecrypt.Text = rsa.DesenRSASecuencial(txtencrypt.Text);
            }
            
            timer.Stop();
            time.Text = "Tiempo: " + Convert.ToString(timer.Elapsed);
        }

        private void txtEncrip_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlano_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
