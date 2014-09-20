using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Multicore.Negocio;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading.Tasks;
//using Multicore.Interfaz;

namespace Multicore
{
    public partial class frmMulticore : Form
    {
        
        public frmMulticore()
        {
            InitializeComponent();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            clsAnalisisTexto insAnalisisTexto = new clsAnalisisTexto();
            
            labelresultado.Text = insAnalisisTexto.analizarTexto(checkParallel.Checked);
            lblCaracteres.Text = insAnalisisTexto.getCantidadCaracteres();
            lblIdioma.Text = insAnalisisTexto.getIdioma();
            lblPalabras.Text = insAnalisisTexto.getCantidadPalagras();
            txtPalabrasComunes.Text = string.Join(" ", insAnalisisTexto.getPalabrasComunes());
        }

        
    }
}
