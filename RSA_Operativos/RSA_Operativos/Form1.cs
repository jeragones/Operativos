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

        RC4_Class rc4 = new RC4_Class();

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
            string m = txtPlano.Text;
            string pass = txtPass.Text;
            
            char[] letras = m.ToCharArray();
            string encrip = "";

            for (int i = 0; i < letras.Length;i++ )
            {
                encrip += rc4.RC4(Convert.ToString(letras[i]), pass);
            }

            txtEncrip.Text = encrip;

            
             
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDesen_Click(object sender, EventArgs e)
        {

            string m = txtEncrip.Text;
            string pass = txtPass.Text;

            char[] letras = m.ToCharArray();
            string encrip = "";

            for (int i = 0; i < letras.Length; i++)
            {
                encrip += rc4.RC4(Convert.ToString(letras[i]), pass);
            }

            txtDesen.Text = encrip;

            

        }

        private void RSA_Load(object sender, EventArgs e)
        {

        }

        private void txtDesen_TextChanged(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
