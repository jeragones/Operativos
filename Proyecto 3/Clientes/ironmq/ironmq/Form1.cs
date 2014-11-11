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
        RabbitMQProducer rcliente = new RabbitMQProducer();
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            var cantidad = cant.Value;
            for (int i = 0; i < cantidad; i++)
            {
                DateTime time = DateTime.Now;
                if (cbIron.Checked && !cbRabbit.Checked)
                {
                    Console.WriteLine("Iron");
                    cliente.sendMessage(i + "-App 1-" + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond);
                }
                else if (cbRabbit.Checked && !cbIron.Checked) 
                {
                    Console.WriteLine("Rabbit");
                    rcliente.Producer(i + "-App 1-" + time.Hour + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond);
                    
                }
                else if (cbIron.Checked && cbRabbit.Checked) 
                {
                    Console.WriteLine("ambos");
                }
            }
        }

        

        

       
    }
}
