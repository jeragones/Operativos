/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package rabbitmq;

import com.rabbitmq.client.Connection;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.*;
/**
 *
 * @author Daniel
 */
public class RabbitMQProducer {
    public static void main(String []args) throws Exception {
        ConnectionFactory factory = new ConnectionFactory();
        factory.setUsername("guest");
        factory.setPassword("guest");
        factory.setVirtualHost("/");
        factory.setHost("127.0.0.1");
        factory.setPort(5672);
        Connection conn = factory.newConnection();
             Channel channel = conn.createChannel();
             String exchangeName = "myExchange";
             String routingKey = "testRoute";
             byte[] messageBodyBytes = "Fuck YOUUUUU!".getBytes();
             channel.basicPublish(exchangeName, routingKey
       ,MessageProperties.PERSISTENT_TEXT_PLAIN, messageBodyBytes) ;
             channel.close();
             conn.close();
    }
}
