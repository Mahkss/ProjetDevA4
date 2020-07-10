/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.reception.ejb_jee7.model;

import java.util.List;
import javax.xml.bind.annotation.XmlElement;

/**
 *
 * @author loicf
 */

/* STRUCTURE DU MESSAGE :
 bool statutOp : Le statut de l’opération en cours (true/flase)
 string info : Un message d’information sur l’opération en cours
 object[] data : Les données utiles à l’exécution de l’opération en cours
 string operationName : Le nom du service invoqué
 string tokenApp : Le code de sécurité de l’application
 string tokenUser : Le code de sécurité après authentification de l’utilisateur
 string appVersion : Le numéro de version de l’application
 string operationVersion : le numéro de version de l’opération demandée
*/

public class MessageSOAPModel {
    private Boolean statusOp;
    private String info;
    private Object[] data;
    private String operationName;
    private String tokenApp;
    private String tokenUser;
    private String appVersion;
    private String operationVersion;

    public MessageSOAPModel() {}
    
    public MessageSOAPModel(Boolean statusOp, String info, Object[] data, String operationName, String tokenApp, String tokenUser, String appVersion, String operationVersion) {
        this.statusOp = statusOp;
        this.info = info;
        this.data = data;
        this.operationName = operationName;
        this.tokenApp = tokenApp;
        this.tokenUser = tokenUser;
        this.appVersion = appVersion;
        this.operationVersion = operationVersion;
    }

    /*-----GETTERs/SETTERS-----*/
    
    @XmlElement(name = "statusOp")
    public Boolean getStatusOp() {
        return statusOp;
    }

    public void setStatusOp(Boolean statusOp) {
        this.statusOp = statusOp;
    }

    @XmlElement(name = "info")
    public String getInfo() {
        return info;
    }

    public void setInfo(String info) {
        this.info = info;
    }

    @XmlElement(name = "data")
    public Object[] getData() {
        return data;
    }

    public void setData(Object[] data) {
        this.data = data;
    }

    @XmlElement(name = "operationName")
    public String getOperationName() {
        return operationName;
    }

    public void setOperationName(String operationName) {
        this.operationName = operationName;
    }

    @XmlElement(name = "tokenApp")
    public String getTokenApp() {
        return tokenApp;
    }

    public void setTokenApp(String tokenApp) {
        this.tokenApp = tokenApp;
    }

    @XmlElement(name = "tokenUser")
    public String getTokenUser() {
        return tokenUser;
    }

    public void setTokenUser(String tokenUser) {
        this.tokenUser = tokenUser;
    }

    @XmlElement(name = "appVersion")
    public String getAppVersion() {
        return appVersion;
    }

    public void setAppVersion(String appVersion) {
        this.appVersion = appVersion;
    }

    @XmlElement(name = "operationVersion")
    public String getOperationVersion() {
        return operationVersion;
    }

    public void setOperationVersion(String operationVersion) {
        this.operationVersion = operationVersion;
    }
    
    
}

