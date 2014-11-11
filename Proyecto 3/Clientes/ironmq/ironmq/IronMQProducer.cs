using IronSharp.IronMQ;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ironmq
{
    class IronMQProducer
    {
        //Servidor IronMQ de Jorge
        IronMqRestClient ironMq = IronSharp.IronMQ.Client.New("545413c2b72d650009000009", "2aps7Lb4F3hMYwtkaVj9xadlRwo");
        
        public void sendMessage(String mens)
        {
            // Get a Queue object
            QueueClient queue = ironMq.Queue("inbox");
            
            // Put a message on the queue
            string messageId = @queue.Post(mens);

            // Get a message
            QueueMessage msg = queue.Get(messageId);

        }
    }
}
