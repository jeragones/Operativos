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
using System.Net;


using System.IO;

namespace ironmq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IronMQProducer cliente = new IronMQProducer();
        RabbitMQProducer rcliente = new RabbitMQProducer();
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            var cantidad = cant.Value;
            for (int i = 0; i < cantidad; i++)
            {
                DateTime time = DateTime.Now;
                if (iron.Checked)
                {
                    Console.WriteLine("Iron");
                    cliente.sendMessage(i + "-App 1-" + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond);
                }
                else if (rabbit.Checked) 
                {
                    Console.WriteLine("Rabbit");
                    rcliente.Producer(i + "-App 1-" + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond);
                    
                }
                else if (terminator.Checked) 
                {
                    // abre una pestaña por cada iteracion de for.. 
                    //System.Diagnostics.Process.Start(url);
                    string ips = ip.Text;
                    string url = "http://" + ips + ":3000/api/post?message=" + i + "-App 1-" + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                    //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    using (var wb = new WebClient())
                    {
                        var resp = wb.DownloadString(url);
                    }
                    Console.WriteLine("terminatorMQ ");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void terminator_CheckedChanged(object sender, EventArgs e)
        {
            ip.Visible = true;
            txtip.Visible = true;
        }

        private void rabbit_CheckedChanged(object sender, EventArgs e)
        {

            ip.Visible = false;
            txtip.Visible = false;
        }

        private void iron_CheckedChanged(object sender, EventArgs e)
        {

            ip.Visible = false;
            txtip.Visible = false;
        }

        

        

       
    }
}
