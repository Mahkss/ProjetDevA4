/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uncipher.receptionfacade.ejb.services;

import com.uncipher.receptionfacade.ejb.model.Message;
import com.uncipher.receptionfacade.ejb.model.MessageData;
import java.util.Collection;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.Stateless;
import javax.jms.JMSException;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.naming.NamingException;

/**
 *
 * @author loicf
 * Classe exposée comme webservice
 */
@Stateless()
@WebService(serviceName="ReceptionMessageService")
public class ReceptionMessageBean {

    /**
     * Recept message request with a encrypt document text
     *
     * @param msg is the encrypt document content envelop.
     * @return a {@link Boolean}
     */
    @WebMethod()
    @WebResult(name = "returnedMessage")
    public Message setMessage(@WebParam(name = "message") Message msg) throws JMSException {
        // Tried to cast Object to MessageData :
        /* MessageData[] msgData = (MessageData[]) msg.getData();
        for (Object obj : msg.getData()) {
            MessageData data = (MessageData) obj;
            System.out.println(data.getContent());
        }*/
        Message newMsg = msg;
        newMsg.setInfo("Zèèèèbi j'ai finis ce que j'avais à faire");
        newMsg.setStatusOp(Boolean.TRUE);
        System.out.println("In progress : " + newMsg.getStatusOp());
        
        // Queue JMS message
        // MessageMDBSender sender = new MessageMDBSender();
        
        /*try {
            sender.sendJMSMessageToReceptionQueue();
            System.out.println("HOLA");
        } catch (NamingException ex) {
            Logger.getLogger(ReceptionMessageBean.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            MessageMDBReceptor.MessageReceptor();
            //System.out.println("HOLA!");
        } catch (NamingException ex) {
            Logger.getLogger(ReceptionMessageBean.class.getName()).log(Level.SEVERE, null, ex);
        }*/
        
        return newMsg;
    }
}
