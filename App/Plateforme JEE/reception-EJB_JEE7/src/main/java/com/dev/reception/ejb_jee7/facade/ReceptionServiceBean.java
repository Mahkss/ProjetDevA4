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
    
    @Resource(lookup = "jms/traitementQueue") //paquetage javax.annotation
    private Queue traitementQueue; //paquetage javax.jms
    
    
    @Override
    public void verifyUncipher(MessageSOAPModel msg) {
        
        /*DocumentSOAPModel document = new DocumentSOAPModel("TITLE", "CONTENT BLABLA BLA");
        Object[] objList = null;
        objList[0] = document;
        System.out.println("objList[0] = "+ objList[0]);
        System.out.println("objList[0]objList[0].getClass() = "+objList[0].getClass() );*/
        DocumentSOAPModel document = (DocumentSOAPModel)msg.getData()[0];
        JAXBContext jaxbContext;
        
        try {
            //obtention d'une instance JAXBContext associée au type Document annoté avec JAX-B
            jaxbContext = JAXBContext.newInstance(DocumentSOAPModel.class);
            //création d'un Marshaller pour transfomer l'objet Java en flux XML
            Marshaller jaxbMarshaller = jaxbContext.createMarshaller();
            StringWriter writer = new StringWriter();
            
            //transformation de l'objet en flux XML stocké dans un Writer
            jaxbMarshaller.marshal(document, writer);
            String xmlMessage = writer.toString();
            //affichage du XML dans la console de sortie
            System.out.println(xmlMessage);
            
            //encapsulation du paiement au format XML dans un objet javax.jms.TextMessage
            TextMessage jmsMsg = context.createTextMessage(xmlMessage); // TODO : swipe test avec ByteMessage
            System.out.println("jmsMsg = " + jmsMsg);
            
            //envoi du message dans la queue receptionQueue
            context.createProducer().send(traitementQueue, jmsMsg);


        } catch (JAXBException ex) {
            System.err.println("SEVERE ERROR : " + ex);
        }
        
        /*System.out.println("Verify uncipher webservice has been called !");
        
        MessageSOAPModel newMsg = msg;
        newMsg.setInfo("Zèèèèbi j'ai finis ce que j'avais à faire");
        newMsg.setStatusOp(Boolean.TRUE);
        System.out.println("In progress : " + newMsg.getStatusOp());
        */
        
    }
}
