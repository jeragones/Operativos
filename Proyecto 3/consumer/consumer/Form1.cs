using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Worker(bool x){
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        datos.guardar(message);
                        string[] msg = message.Split('-');
                        if (msg[1] == "App 1")
                        {
                            msgs.SelectionColor = Color.Red;
                            msgs.AppendText(msg[0] + " " + msg[1] + " " + msg[2] + " " + "\n");
                        }
                        else
                        {
                            msgs.SelectionColor = Color.Blue;
                            msgs.AppendText(message + "\n");
                        }
                        Console.WriteLine(" [x] Received {0}", message);
                        
                    }
                }
            }
        }

        Datos datos = new Datos();
        private void button1_Click(object sender, EventArgs e)
        {

            Worker(true);          

           
        }
    }
}
