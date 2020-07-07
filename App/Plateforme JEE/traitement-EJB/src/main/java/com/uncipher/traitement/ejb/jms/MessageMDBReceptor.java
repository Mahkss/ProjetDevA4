/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uncipher.traitement.ejb.jms;

import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.MessageListener;  
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
  
/** 
 * 
 * @author loicf 
 */  
public class MessageMDBReceptor implements MessageListener {  

    @JMSConnectionFactory("java:comp/jms/ReceptionConnection")
    private JMSContext context;
      
    public static void MessageReceptor() throws JMSException, NamingException { 
        Context context = new InitialContext();
      ConnectionFactory factory = (ConnectionFactory) context.lookup("jms/ReceptionConnection");
      Destination destination = (Destination) context.lookup("jms/ReceptionQueue");
      Connection connection = factory.createConnection();
      Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
      MessageConsumer receiver = session.createConsumer(destination);
      connection.start();
      
      Message message = receiver.receive();
      if (message instanceof TextMessage) {
          TextMessage text = (TextMessage) message;
          System.out.println("message recu= " + text.getText());
        } else if (message != null) {
          System.out.println("Aucun message dans la file");
        }
    }
  
    public void onMessage(Message message) { 
        if (message instanceof TextMessage) {  
            TextMessage tm = (TextMessage) message;  
            try {  
                String text = tm.getText();  
                System.out.println("Received new message :" + text);  
            } catch (JMSException e) {
            } 
        }
    }  
      
}