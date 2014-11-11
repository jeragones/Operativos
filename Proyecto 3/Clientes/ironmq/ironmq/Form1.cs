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
                    string url = "http://172.24.19.79:3000/api/post?message=" + i + "-App+2-12%3A23%3A23%3A123";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    
                    Console.WriteLine("terminatorMQ ");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        

       
    }
}
