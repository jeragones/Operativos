using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sort_Methods.App_Code;

namespace Sort_Methods
{
    public partial class Form1 : Form
    {
        FileClass insFile = new FileClass();
        QuickSort insQuick = new QuickSort();
        MergeSort insMerge = new MergeSort();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdbAscMerge.Checked = true;
            rdbAscQuick.Checked = true;
            rdbMergeSecuential.Checked = true;
            rdbQuickSecuential.Checked = true;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            
            insFile.loadFile();
        }

        private void btnMergeSort_Click(object sender, EventArgs e)
        {
            lblMergeTime.Text = insMerge.mergeSortTime(insFile, rdbAscMerge.Checked, rdbMergeSecuential.Checked);
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            lblQuickTime.Text = insQuick.quickSortTime(insFile, rdbAscQuick.Checked, rdbQuickSecuential.Checked);
        }

        private void rdbQuickSecuential_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblMergeTime_Click(object sender, EventArgs e)
        {

        }
    }
}
