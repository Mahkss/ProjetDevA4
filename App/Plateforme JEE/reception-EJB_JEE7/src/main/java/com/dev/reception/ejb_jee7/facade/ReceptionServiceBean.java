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
import javax.xml.ws.BindingType;

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
// @BindingType("http://java.sun.com/xml/ns/jaxws/2003/05/soap/bindings/HTTP/")        //to support [application/soap+xml] content-type request insteed of [text/xml]
public class ReceptionServiceBean implements ReceptionServiceEndPointInterface {

    @Inject //paquetage javax.inject
    private JMSContext context; //paquetage javax.jms
    
    @Resource(lookup = "jms/receptionQueue") //paquetage javax.annotation
    private Queue receptionQueue; //paquetage javax.jms
    
    
    @Override   // text is in base64 because the WStxParsing catch exception when illegal character
    public boolean verifyUncipher(String base64text, String usedKey, String fileName) {
        boolean res = false;
        
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
        /*System.out.println("Verify uncipher webservice has been called !");
        
        MessageSOAPModel newMsg = msg;
        newMsg.setInfo("Zèèèèbi j'ai finis ce que j'avais à faire");
        newMsg.setStatusOp(Boolean.TRUE);
        System.out.println("In progress : " + newMsg.getStatusOp());
        */
        
    }
}
