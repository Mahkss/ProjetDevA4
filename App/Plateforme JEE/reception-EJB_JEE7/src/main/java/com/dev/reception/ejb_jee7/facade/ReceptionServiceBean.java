/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.reception.ejb_jee7.facade;

import com.dev.reception.ejb_jee7.model.DocumentSOAPModel;
import com.dev.reception.ejb_jee7.model.MessageSOAPModel;
import java.io.StringWriter;
import java.util.List;
import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.Queue;
import javax.jms.TextMessage;
import javax.jws.WebService;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

/**
 *  Stateless reception session bean
 * @author loicf
 */
@Stateless
@WebService(
        endpointInterface = "com.dev.reception.ejb_jee7.facade.ReceptionServiceEndPointInterface",
        portName = "receptionPort",
        serviceName = "receptionService"
)   // endpointInt : obligatoire car implémente le SEI ; portName & serviceName : noms balises WSDL
public class ReceptionServiceBean implements ReceptionServiceEndPointInterface {

    @Inject //paquetage javax.inject
    private JMSContext context; //paquetage javax.jms
    
    @Resource(lookup = "jms/receptionQueue") //paquetage javax.annotation
    private Queue receptionQueue; //paquetage javax.jms
    
    
    @Override
    public boolean verifyUncipher(String base64text, String usedKey, String fileName) {
        boolean res = false;
        
        System.out.println("File: "+ fileName +" with key "+ usedKey +" is being analyzed !");


        if(base64text != null && !base64text.equals("") && usedKey != null && !usedKey.equals("") && fileName != null && !fileName.equals("")){
            try{
                //création du message
                TextMessage msg = context.createTextMessage(base64text);
                msg.setStringProperty("key",usedKey);
                msg.setStringProperty("name",fileName);
                //envoi du message dans la queue checkQueue
                context.createProducer().send(receptionQueue, msg);
                res = true;
            }catch(Exception e){
                System.out.println("CheckQueue Error : " + e);
            }
        }
        return res;        
        
    }
}
