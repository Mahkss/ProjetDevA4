/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.reception.ejb_jee7.facade;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.TextMessage;

/**
 *
 * @author loicf
 */
public class SenderWebService implements MessageListener {

    // TODO : Unused method du to broken connection ...
    public SenderWebService() {
    }

    public void onMessage(Message message) {
        if (message instanceof TextMessage) { 
            TextMessage tm = (TextMessage) message;  
            try {
                String text = tm.getText();  
                System.out.println("Received new message :" + text);
                this.sendRequest();
            } catch (JMSException e) {
            }
        }
    }
    
    public void sendRequest() {
        try {
            String url = "http://localhost:55555";  // port middleware .NET
            URL obj = new URL(url);
            HttpURLConnection con = (HttpURLConnection) obj.openConnection();
            con.setRequestMethod("POST");
            con.setRequestProperty("Content-Type", "application/soap+xml; charset=utf-8");
            String countryCode = "Canada";
            String xml = "<S:Envelope xmlns:S=\"http://schemas.xmlsoap.org/soap/envelope/\">\n"
                    + "   <S:Body>\n"
                    + "      <ns2:setMessageResponse xmlns:ns2=\"http://services.ejb.receptionfacade.uncipher.com/\">\n"
                    + "         <returnedMessage>\n"
                    + "            <appVersion>1.0</appVersion>\n"
                    + "            <data>[{\"title\" : \"fichier.txt\", \"content\" : \"txt a déchifffffffrer oui bonhomme\"}]</data>\n"
                    + "            <info>Zèèèèbi j'ai finis ce que j'avais à faire</info>\n"
                    + "            <operationName>verification</operationName>\n"
                    + "            <operationVersion>1</operationVersion>\n"
                    + "            <statusOp>true</statusOp>\n"
                    + "            <tokenApp>123456789</tokenApp>\n"
                    + "            <tokenUser>123456789</tokenUser>\n"
                    + "         </returnedMessage>\n"
                    + "      </ns2:setMessageResponse>\n"
                    + "   </S:Body>\n"
                    + "</S:Envelope>";
            con.setDoOutput(true);
            DataOutputStream wr = new DataOutputStream(con.getOutputStream());
            wr.writeBytes(xml);
            wr.flush();
            wr.close();
            String responseStatus = con.getResponseMessage();
            System.out.println(responseStatus);
            // TODO : bufferReader the input flux data
        } catch (Exception e) {
            System.out.println(e);
        }
    }
}
