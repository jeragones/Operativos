/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ironmq;

import io.iron.ironmq.Client;
import io.iron.ironmq.Cloud;
import io.iron.ironmq.Message;
import io.iron.ironmq.Queue;
import io.iron.ironmq.QueueModel;
import io.iron.ironmq.Queues;
import java.io.IOException;
import java.util.ArrayList;

/**
 *
 * @author Daniel
 */
public class Ironmq {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        // TODO code application logic here
        
        Client client = new Client("545413c2b72d650009000009", "2aps7Lb4F3hMYwtkaVj9xadlRwo");
        
        System.err.println(client.getOptions());
        Queue queue = client.queue("EntryQueue");
        
        

        // Put a message on the queue
        queue.push("Hello, world!");

        // Get a message
        Message msg = queue.get();

        // Delete the message
        queue.deleteMessage(msg);

    }
    
}
