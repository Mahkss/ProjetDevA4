/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.uncipher.traitement.ejb.jms;

import java.io.Serializable;

/**
 *
 * @author loicf
 */
public class CommunicationMessage implements Serializable {
    
    private static final long serialVersionUID = 1L;
    private String name;
    private String message;
    
    public CommunicationMessage(String name, String message) {
        super();
        this.name = name;
        this.message = message;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}
