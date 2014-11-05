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
        IronMqRestClient ironMq = IronSharp.IronMQ.Client.New("545413c2b72d650009000009", "2aps7Lb4F3hMYwtkaVj9xadlRwo");
        
        public void sendMessage(String mens)
        {
            // Get a Queue object
            QueueClient queue = ironMq.Queue("EntryQueue");
            
            // Put a message on the queue
            string messageId = @queue.Post(mens);

            //Console.WriteLine(messageId);

            // Get a message
            QueueMessage msg = queue.Get(messageId);

            //Console.WriteLine(msg.Body);

            /*
            //# Delete the message
            //bool deleted = msg.Delete();

           // Console.WriteLine("Deleted = {0}", deleted);
            */

        }

        public object[] ibox()
        {
            object[] res = new object[2]; 
            QueueClient queue = ironMq.Queue("EntryQueue");

            MessageCollection messages = queue.Get(n: 2, timeout: 60);
            // You can specify only parameters you need:
            // MessageCollection messages = queue.Get(wait: 15);

            QueueInfo info = queue.Info();

            //Console.WriteLine(info.TotalMessages);
            
            QueueMessage next;

            ArrayList inbox = new ArrayList();
            while (queue.Read(out next))
            {
                Console.WriteLine(next.Body);
                Console.WriteLine(next.Delete());
                inbox.Add(next.Body);
                
            }
            res[0] = inbox;
            res[1] = info.TotalMessages;
            return res;
        }
        

    }
}
