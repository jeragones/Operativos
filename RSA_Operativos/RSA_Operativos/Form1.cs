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

        RSA_Class rsa = new RSA_Class();

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
            
             int p =0;
             int q =0;

            try
            {
                p = Convert.ToInt32(ps);
                q = Convert.ToInt32(qs);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            rsa.generar_public(p,q);          
            string c = "";
            char[] letras =m.ToCharArray();
            progres.Maximum = letras.Length-1;
            for (int i = 0; i < letras.Length; i++)
            {
                progres.Value = i;
                c = c + Convert.ToChar(rsa.EncriptarRSA(p, q, letras[i]));
            }
                
            txtEncrip.Text = c;
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
            string ps = txtP.Text;
            string qs = txtQ.Text;
            string m = txtEncrip.Text;

            int p = 0;
            int q = 0;

            try
            {
                p = Convert.ToInt32(ps);
                q = Convert.ToInt32(qs);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            rsa.generar_private(p, q);
            string c = "";
            char[] letras = m.ToCharArray();
            progres.Maximum = letras.Length - 1;
            for (int i = 0; i < letras.Length; i++)
            {
                progres.Value = i;   
                c = c + Convert.ToChar(rsa.DesEncriptarRSA(p, q, letras[i])); 
            }
            txtDesen.Text = c;

        }

        private void RSA_Load(object sender, EventArgs e)
        {

        }

        private void txtDesen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
