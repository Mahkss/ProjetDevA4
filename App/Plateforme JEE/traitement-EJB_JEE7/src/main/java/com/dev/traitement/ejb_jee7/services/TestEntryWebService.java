/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.traitement.ejb_jee7.services;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.ejb.Stateless;

/**
 *
 * @author loicf
 */
@WebService(serviceName = "MainWebService")
@Stateless()
public class MainWebService {

    /**
     * This is a sample web service operation TEST
     */
    @WebMethod(operationName = "MainService")
    public void mainService() {
        String docName = "FILE01";
        String document = "Je suis un texte inutile blanc vide de sens qui n'est la que pour combler un vide, d'ailleurs arrêtez immédiatemment de me lire, ceci est une perte de temps l'information secrète est : BUSCO. Merci pour votre attention";
        
        DocumentAnalysisService docAnal = new DocumentAnalysisService(docName, document);
        docAnal.DictionaryVerification();
    }
}
