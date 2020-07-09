/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.reception.ejb_jee7.facade;

import com.dev.reception.ejb_jee7.model.MessageSOAPModel;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

/**
 *  Stateless reception session bean interface endpoint (SEI)
 * @author loicf
 */
@WebService(name="ReceptionEndPoint")   // = nom de l'élément XML <wsdl:portype>
public interface ReceptionServiceEndPointInterface {
    @WebMethod(operationName = "receptionOperation")
    @WebResult(name = "acceptedReception")  // = nom de la balise parent XML qui sera retournée avec les résultats dedans
    void verifyUncipher(@WebParam(name = "message")MessageSOAPModel msg);
}
