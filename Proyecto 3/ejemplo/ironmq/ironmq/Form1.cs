using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ironmq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IronMQProducer cliente = new IronMQProducer();

        private void button1_Click(object sender, EventArgs e)
        {
            var cantidad = cant.Value;
            string msg = mens.Text;
            for (int i = 1; i <= cantidad; i++)
            {
                cliente.sendMessage("Mensaje: "+msg+ " Desde: App1");
                //inbox.Text = inbox.Text + "Mensaje Numero: " + i + " Mensaje: " + msg + " Desde: App1\n";
                /*object[] res = cliente.ibox();
                ArrayList msgs = (ArrayList)res[0];
                cola.Text = "Cola: " + res[1];
                foreach(String mg in msgs)
                {
                    inbox.Text = inbox.Text + mg + "\n";
                }
                
                */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inbox.Text = "";
            object[] res = cliente.ibox();
            ArrayList msgs = (ArrayList)res[0];
            cola.Text = "Cola: " + res[1];
            foreach (String mg in msgs)
            {
                inbox.Text = inbox.Text + mg + "\n";
            }
        }

       
    }
}
