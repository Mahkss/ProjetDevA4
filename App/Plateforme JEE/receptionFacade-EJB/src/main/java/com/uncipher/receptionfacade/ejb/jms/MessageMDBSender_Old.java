/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uncipher.receptionfacade.ejb.jms;

import javax.annotation.Resource;
import javax.jms.ConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.JMSProducer;
import javax.jms.Message;
import javax.jms.Queue;
import javax.jms.Session;
import javax.jms.TextMessage;

/**
 *
 * @author loicf
 */
/*
public class MessageMDBSender_Old {
    
    
    @Resource(mappedName = "jms/ReceptionConnection")
    private ConnectionFactory connectionFactory;
    
    @Resource(mappedName = "jms/ReceptionQueue")
    private Queue queue;
    
    public MessageMDBSender_Old() {
        JMSContext jmsContext = connectionFactory.createContext();
        
        JMSProducer jmsProducer = jmsContext.createProducer();
        
        //CommunicationMessage message = new CommunicationMessage("FileName", "Je mange des putains de poutres");
        String message = "Hello JMS!!!!!!!!";
        System.out.println("Sending message to JMS : ");
        
        jmsProducer.send(queue, message);
        
        System.out.println("Message send successfuly !!!");
    }

    private Message createJMSMessageForjmsReceptionQueue(Session session, Object messageData) throws JMSException {
        // TODO create and populate message to send
        TextMessage tm = session.createTextMessage();
        tm.setText(messageData.toString());
        return tm;
    }
}*/
