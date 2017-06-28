/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº2.pkg1;

/**
 *
 * @author Enzo
 */
public class Domicilio {
   
    private String calle;        
    private int numeroCalle;
    private Cliente refCliente;

    public Domicilio() {
    }

    public Domicilio(String calle, int numeroCalle) {
        this.calle = calle;
        this.numeroCalle = numeroCalle;
    }

    public Cliente getRefCliente() {
        return refCliente;
    }
    public void setRefCliente(Cliente refCliente) {
        this.refCliente = refCliente;
    }   
    public int getNumeroCalle() {
        return numeroCalle;
    }
    public void setNumeroCalle(int numeroCalle) {
        this.numeroCalle = numeroCalle;
    }
    public String getCalle() {
        return calle;
    }
    public void setCalle(String calle) {
        this.calle = calle;
    }
    
}