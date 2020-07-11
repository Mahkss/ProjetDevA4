/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.traitement.ejb_jee7.services;

import com.dev.traitement.ejb_jee7.database.EntityManager;
import java.io.Console;
import java.nio.charset.StandardCharsets;
import java.text.Collator;
import java.util.Random;
import java.util.Arrays;
import java.util.Base64;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.naming.NamingException;
import javax.xml.ws.WebServiceRef;
//import org.datacontract.schemas._2004._07.contract.MSG;
//import org.datacontract.schemas._2004._07.contract.ObjectFactory;
//import org.tempuri.MessagingComponent;

/**
 *
 * @author loicf
 */
public class DocumentAnalysisService {
    
    //@WebServiceRef(wsdlLocation = "META-INF/wsdl/localhost_8010/Service/.wsdl")
    //private MessagingComponent service;
    
    String docName;
    String document; // Text document
    String key;
    String[] docList;
    int maxDocSampleSize = 25; // In words
    double nbrMatchWords = 0;
    double rateMatchWords = 0; // [0-1]
    double rateToReach = 0.7;
    EntityManager entityManager;
    // It's a regex match without voyels accents (ex: été = ete)
    final Collator instance = Collator.getInstance();
    String regexPonctuation = "[~`!@#$%^&º¬§*()\\{}\\[\\];:\"'<,.>?\\/\\\\|_+=-]";
    String regexCarriages = "\\r\\n";
    String regexDoubleSpace = "\\s\\s+";
    String regexSpace = "\\s";
    boolean isPrecossInValid = false;
    
    // --- CONSTRUCTOR --- //
    public DocumentAnalysisService(String docName, String document, String key) {
        ///System.out.println("Info: DocumentAnalysisService instanciated");

        this.key = key;
        this.entityManager = new EntityManager();
        byte[] byteArray = Base64.getDecoder().decode(document);
        String decodedString = new String(byteArray, StandardCharsets.UTF_8);
        ///System.out.println("decodedString = " + decodedString);
        
        // Regex text document : remove all ponctuations  > new lines / carriages return becomes inline spaces > multiple spaces becomes one
        // DOCNAME
        this.docName = docName.split("\\.")[0];
        // DOCUMENT
        String step1 = decodedString.replaceAll(regexPonctuation,"");
        String step2 = step1.replaceAll(regexCarriages, " ");
        String step3 = step2.replaceAll(regexDoubleSpace, " ");
        ///System.out.println("After regex : " + this.key + " : " + step3);
        this.document = step3;
        // Split each document word into an array
        this.docList = this.document.split(" ");
        this.constructorCheckWordLength();
        // Init instance to ignore the accents
        this.instance.setDecomposition(Collator.NO_DECOMPOSITION); // -> instance.compare("été", "ete") == 0
        
    }
    
    // if a word is longer than 25 char, abandon the verification (biggest fr word == 25)
    private void constructorCheckWordLength() {
        int index = 0;
        while(this.isPrecossInValid == false && index < 50 && index < this.docList.length) {
            if (this.docList[index] != null && this.docList[index].length() > 25) {
                this.isPrecossInValid = true;
                System.out.println("Abandon : " + key);
            }
            index++;
        }
    }
    
    // --- DOCUMENT MAIN PROCESSORS --- //
    // Check well decrypted document
    public void DictionaryVerification() {
        String tableName = this.docName;
        String[] docSegList = this.cropDocumentSegment(this.docList);
        
        // Document DB save & analysis
        if (!entityManager.loadTable(tableName)) {
            ///System.out.println("Document DB table initializing ...");    // fileName first version
            // Create new table corresponding to the document
            if (entityManager.createTable(tableName)) {
                ///System.out.println("Inserting table statement...");
                ///System.out.println("-----------------------------------------------------");
                for (String docSegList1 : docSegList) {
                    try {
                        entityManager.insertTable(docName, docSegList1);
                    }catch(Exception e) {
                        System.out.println("Failed to insert a row in DB table : " + e);
                    }
                }
            }
        } else {
            // Get the saved table (avoid a new storage process)
            ///System.out.println("Document DB table overwriting ...");     // already get this fileName (but with different content)
            if (entityManager.deleteTable(tableName)) {
                ///System.out.println("Inserting table statement...");
                ///System.out.println("-----------------------------------------------------");
                for (String docSegList1 : docSegList) {
                    try {
                        entityManager.insertTable(docName, docSegList1);
                    }catch(Exception e) {
                        System.out.println("Failed to insert a row in DB table : " + e);
                    }
                }
            }
        }
        // Inner join with dictionary table to calculate corresponding rate > display table data & rate score > close DB connection & statement
        entityManager.loadDicoInnerJoin(tableName);
        //entityManager.dispResultData();
        this.nbrMatchWords = entityManager.countDicoMatch(tableName);
        this.rateMatchWords = this.nbrMatchWords / docSegList.length;
        ///System.out.println("Dico match rate : "+this.rateMatchWords);
        entityManager.closeConn();
        
        // Launch secret word searcher if the rate is ok
        if (this.rateMatchWords >= this.rateToReach) {
            this.FindSecretWord();
        }
    }
    
    // Find document secret word /!\only if document has been well decrypted/!\
    public void FindSecretWord() {
        String secretWord = null;
        String charAmorce1 = "linformation";
        String charAmorce2 = "secrète";
        String charAmorce22 = "secrete";
        String charAmorce3 = "est";
        
        // Extract secret word of the document text
        for (int i = 0; i < this.docList.length; i++) {
            // Search "secrète" word in doc
            if (instance.compare(this.docList[i].toLowerCase(), charAmorce2) == 0
                || instance.compare(this.docList[i].toLowerCase(), charAmorce22) == 0) {
                // Check if there is "linformation" word before "secrète"
                if (instance.compare(this.docList[i-1].toLowerCase(), charAmorce1) == 0) {
                    // Check if there is "est" word after "secrète"
                    if (instance.compare(this.docList[i+1].toLowerCase(), charAmorce3) == 0) {
                        // The word after "information secrète est" will be the secret word
                        secretWord = this.docList[i+2];
                    }
                }
            }
        }
        // Disp the result
        if (secretWord != null) {
            System.out.println("----------------------BINGOOOOO----------------------");
            System.out.println("Mot secret >"+secretWord+"< !!!");
            
            
        } else {
            System.out.println("No secret word founded.");
        }
        
        System.out.println("Dico match rate : "+this.rateMatchWords);
        System.out.println("Document text = " + this.document);
        System.out.println("-----------------------------------------------------");

        
        // Send in a queue a rapport message
        //sendResults(initMSG(docName));
    }
    
    /* Crop a random document segment */
    private String[] cropDocumentSegment(String[] docList) {
        String[] documentSegment = null; // Segment of document
        
        // Pick up a random min of 50 words of the document
        if (docList.length > this.maxDocSampleSize) {   // Doc length = 100
            Random r = new Random();
            int beginMaxIndex = docList.length- this.maxDocSampleSize;  //beginMaxIndex = 75
            int randomBeginIndex = r.nextInt((beginMaxIndex - 0)+1);    // randomBeginIndex = random(0-75) => 100 - 25
            documentSegment = Arrays.copyOfRange(docList, randomBeginIndex, (randomBeginIndex + this.maxDocSampleSize));
            ///System.out.println("Croped document : " + documentSegment.length + " words (from "+docList.length+")");
        } else {
            documentSegment = docList;
            ///System.out.println("Complete document : " + Arrays.toString(documentSegment)); 
        }


        return documentSegment;
    }
    
    
    private void sendResults(/*MSG msg*/){
        /*
        try { 
            // Call Web Service Operation
            org.tempuri.IContract port = service.getProjCrossPlatformCommunicationBS();
            // TODO process result here
            MSG result = port.mService(msg);
            System.out.println("Result = "+result.getInfo().getValue()+" : "+result.isOpStatut());
        } catch (Exception ex) {
            // TODO handle custom exceptions here
            System.out.print(ex);
        }*/
    }
    
    /*
    private MsgKey initMSG(String token){
        MSG msg = new MSG();
        ObjectFactory factory = new ObjectFactory();
        ArrayOfanyType msgData = new ArrayOfanyType();
        msgData.getAnyType().add(shared.getKey(token)); 
        msgData.getAnyType().add(shared.getPercent(token)); 
        msgData.getAnyType().add(shared.getSecret(token)); 
        
        msg.setTokenApp(factory.createMSGTokenApp("811-comDev20"));
        msg.setOpStatut(false);
        msg.setInfo(factory.createMSGInfo(""));
        msg.setData(factory.createMSGData(msgData));
        msg.setTokenUser(factory.createMSGTokenUser(token));
        msg.setAppVersion(factory.createMSGAppVersion("1.0"));
        msg.setOperationName(factory.createMSGOperationName("receiveXMLMessage"));
        msg.setOperationVersion(factory.createMSGOperationVersion("1.0"));
        
        return msg;
    }*/
}
