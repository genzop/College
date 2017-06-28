/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg2.ejercicio.pkg2;

import java.util.ArrayList;

/**
 *
 * @author Enzo
 */
public class Cliente {
    
    private int nroCliente;    
    private String razonSocial;
    private ArrayList<Factura> facturas;

    public Cliente() {
    }

    public Cliente(int nroCliente, String razonSocial) {
        this.nroCliente = nroCliente;
        this.razonSocial = razonSocial;
        this.facturas = new ArrayList();
    }  

    public String getRazonSocial() {
        return razonSocial;
    }
    public void setRazonSocial(String razonSocial) {
        this.razonSocial = razonSocial;
    }
    public int getNroCliente() {
        return nroCliente;
    }
    public void setNroCliente(int nroCliente) {
        this.nroCliente = nroCliente;
    }
    
    public void agregarFactura(Factura facturaNueva){
        this.facturas.add(facturaNueva);
        facturaNueva.setCliente(this);
    }

    public double getTotalFacturasXAnio(int anio){
        double totalFacturasXAnio = 0;
        for (Factura f : facturas) {           
            if (f.getFecha().getYear() == anio) {
                totalFacturasXAnio += f.getTotalFactura();
            }
        }
        return totalFacturasXAnio;               
    }

    public double getTotalFacturasActivas(){
        double totalFacturasActivas = 0;
        for (Factura f : facturas) {
            if (!f.isAnulada()) {
                totalFacturasActivas += f.getTotalFactura();
            }
        }
        return totalFacturasActivas;
    }
}