/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.traitement.ejb_jee7.services;

import java.nio.charset.StandardCharsets;
import java.util.Base64;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.TextMessage;
import javax.xml.ws.WebServiceRef;

/**
 *
 * @author loicf
 */
@MessageDriven(mappedName = "jms/receptionQueue", activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class MainListener implements MessageListener {
    
    // JMS Queue messages listener implementation
    @Override
    public void onMessage(Message message) {
        System.setProperty("javax.xml.soap.SAAJMetaFactory", "com.sun.xml.messaging.saaj.soap.SAAJMetaFactoryImpl");
        try{
            if(message != null){
                //Recupère les données du message
                String text = ((TextMessage)message).getText();
                String fileName = message.getStringProperty("name") != null ? message.getStringProperty("name") : "FILE-DEFAULTNAME";
                String key = message.getStringProperty("key");
                ///System.out.println("Get queue msg ! Name : " + fileName);
                
                DocumentAnalysisService docAnal = new DocumentAnalysisService(fileName, text, key);
                if (!docAnal.isPrecossInValid) {
                    docAnal.DictionaryVerification();
                }
            }
        }catch(Exception e){
            System.out.println("OnMessage Error : "+e.getMessage());
        }
    }
}
