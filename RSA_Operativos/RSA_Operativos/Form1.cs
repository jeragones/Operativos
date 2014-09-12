using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_Operativos
{
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrip_Click(object sender, EventArgs e)
        {
            string ps = txtP.Text;
            string qs = txtQ.Text;
            string m = txtPlano.Text;
            txtEncrip.Text = m;
            try
            {
                int p = Convert.ToInt32(ps);
                int q = Convert.ToInt32(qs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        private void btnDesen_Click(object sender, EventArgs e)
        {

        }
    }
}
