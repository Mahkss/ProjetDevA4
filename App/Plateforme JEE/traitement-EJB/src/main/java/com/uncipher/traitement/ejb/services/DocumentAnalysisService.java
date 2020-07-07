/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uncipher.traitement.ejb.services;

import com.uncipher.traitement.ejb.entity.EntityManager;
import java.lang.reflect.Array;
import java.text.Collator;
import java.util.Random;
import java.util.Arrays;

/**
 *
 * @author loicf
 */
public class DocumentAnalysisService {
    
    String docName;
    String document; // Text document
    String[] docList;
    int maxDocSampleSize = 25; // In words
    double nbrMatchWords = 0;
    double rateMatchWords = 0; // [0-1]
    double rateToReach = 0.3;
    EntityManager entityManager;
    // It's a regex match without voyels accents (ex: été = ete)
    final Collator instance = Collator.getInstance();
    
    // --- CONSTRUCTOR --- //
    public DocumentAnalysisService(String docName, String document) {
        System.out.println("Info: DocumentAnalysisService instanciated");

        this.docName = docName;
        this.entityManager = new EntityManager();

        // Regex text document : remove all ponctuations  > new lines / carriages return becomes inline spaces > multiple spaces becomes one
        String step1 = document.replaceAll("[~`!@#$%^&º¬§*()\\{}\\[\\];:\"'<,.>?\\/\\\\|_+=-]","");
        String step2 = step1.replaceAll("\\r\\n", " ");
        String step3 = step2.replaceAll("\\s\\s+", " ");
        System.out.println("After regex : " + step3);
        this.document = step3;
        // Split each document word into an array
        this.docList = this.document.split(" ");
        // Init instance to ignore the accents
        this.instance.setDecomposition(Collator.NO_DECOMPOSITION); // -> instance.compare("été", "ete") == 0
        
    }
    
    // TODO : JMS onMessage() implement

    
    // --- DOCUMENT MAIN PROCESSORS --- //
    // Check well decrypted document
    public void DictionaryVerification() {
        String tableName = this.docName;
        String[] docSegList = this.cropDocumentSegment(this.docList);
        
        // Document DB save & analysis
        if (!entityManager.loadTable(tableName)) {
            System.out.println("Document exist po...");
            // Create new table corresponding to the document
            if (entityManager.createTable(tableName)) {
                for (int i = 0; i < docSegList.length; i++) {
                    try {
                        entityManager.insertTable(docName, docSegList[i]);
                    } catch(Exception e) {
                        System.out.println("Failed to insert a row in DB table : " + e);
                    }
                }
            }
        } else {
            // Get the saved table (avoid a new storage process)
            System.out.println("Document exist!");
        }
        // Inner join with dictionary table to calculate corresponding rate > display table data & rate score > close DB connection & statement
        entityManager.loadDicoInnerJoin(tableName);
        //entityManager.dispResultData();
        this.nbrMatchWords = entityManager.countDicoMatch(tableName);
        this.rateMatchWords = this.nbrMatchWords / docSegList.length;
        System.out.println("Dico match rate : "+this.rateMatchWords);
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
        String charAmorce3 = "est";
        
        // Extract secret word of the document text
        for (int i = 0; i < this.docList.length; i++) {
            // Search "secrète" word in doc
            if (instance.compare(this.docList[i], charAmorce2) == 0) {
                // Check if there is "linformation" word before "secrète"
                if (instance.compare(this.docList[i-1], charAmorce1) == 0) {
                    // Check if there is "est" word after "secrète"
                    if (instance.compare(this.docList[i+1], charAmorce3) == 0) {
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

        // TODO : send in a queue a rapport message
        // ...
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
            System.out.println("Croped document : " + documentSegment.length + " words (from "+docList.length+")");
        } else {
            documentSegment = docList;
            System.out.println("Complete document : "+ documentSegment); 
        }


        return documentSegment;
    }
}
