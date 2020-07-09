/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.traitement.ejb_jee7.jms;

import com.dev.traitement.ejb_jee7.services.DocumentAnalysisService;
import java.io.Serializable;
import javax.ejb.ActivationConfigProperty;  
import javax.ejb.MessageDriven;  
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;  
import javax.jms.Message;  
import javax.jms.MessageListener;  
import javax.jms.Session;
import javax.jms.TextMessage;  
import javax.naming.Context;
import javax.naming.InitialContext;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageProducer;
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

    @JMSConnectionFactory("java:comp/jms/__defaultConnectionFactory")
    private JMSContext context;
      
    public static void MessageReceptor() throws JMSException, NamingException { 
        Context context = new InitialContext();
      ConnectionFactory factory = (ConnectionFactory) context.lookup("jms/__defaultConnectionFactory");
      Destination destination = (Destination) context.lookup("jms/receptionQueue");
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
                DocumentAnalysisService docAnal = new DocumentAnalysisService("xFILE", text);
                docAnal.DictionaryVerification();
            } catch (JMSException e) {
            }
        }
    }  
      
}