/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.reception.ejb_jee7.model;

import java.io.Serializable;

/**
 *
 * @author loicf
 */
public class DocumentSOAPModel implements Serializable{
    
    private static final long serialVersionUID = 1L;
    private String title;
    private String content;

    public DocumentSOAPModel(String title, String content) {
        this.title = title;
        this.content = content;
    }
    
    
    public String getTitle() {
        return title;
    }
    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }
    public void setContent(String content) {
        this.content = content;
    }
    
    
}
