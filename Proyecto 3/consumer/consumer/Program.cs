using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Program
    {
        static void worker() 
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);

                    Console.WriteLine(" [*] Waiting for messages." +
                                             "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Datos.guardar(message);
                        string[] msg = message.Split('-');
                        if (msg[1] == "App 1")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(msg[0] + " " + msg[1] + " " + msg[2] );
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(msg[0] + " " + msg[1] + " " + msg[2] );
                        }
                        
                    }
                }
            }
        }

       static void Main(string[] args)
        {
            worker();
        }
    }
}
