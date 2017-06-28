/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº2.pkg1;

import java.util.ArrayList;

/**
 *
 * @author Enzo
 */
public class Cliente {
    
    private String denominacion;        
    private String cuit;
    private Domicilio refDomicilio;
    private ArrayList<Factura> refFacturas;

    public Cliente() {
    }
    
    public Cliente(String denominacion, String cuit, String calle, int numeroCalle) {
        this.denominacion = denominacion;
        this.cuit = cuit;
        this.refFacturas = new ArrayList();
        refDomicilio = new Domicilio(calle, numeroCalle);
    }

    public Domicilio getRefDomicilio() {
        return refDomicilio;
    }
    public void setRefDomicilio(Domicilio refDomicilio) {
        this.refDomicilio = refDomicilio;
    }
    public ArrayList<Factura> getRefFacturas() {
        return refFacturas;
    }
    public void setRefFacturas(ArrayList<Factura> refFacturas) {
        this.refFacturas = refFacturas;
    }   
    public String getCuit() {
        return cuit;
    }
    public void setCuit(String cuit) {
        this.cuit = cuit;
    }
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }
    
    public void agregarFactura(Factura facturaNueva){
        this.refFacturas.add(facturaNueva);
        facturaNueva.setRefCliente(this);
    }
}