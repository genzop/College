/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg2.ejercicio.pkg2;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author Enzo
 */
public class Factura {
    
    private int numero;    
    private Date fecha;    
    private boolean anulada;
    private Cliente cliente;
    private ArrayList<DetalleFactura> detalles;

    public Factura() {
    }

    public Factura(int numero, Date fecha, boolean anulada) {
        this.numero = numero;
        this.fecha = fecha;
        this.anulada = anulada;
        this.detalles = new ArrayList();
    }

    public Cliente getCliente() {
        return cliente;
    }
    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }
    public ArrayList<DetalleFactura> getDetalles() {
        return detalles;
    }
    public void setDetalles(ArrayList<DetalleFactura> detalles) {
        this.detalles = detalles;
    }   
    public boolean isAnulada() {
        return anulada;
    }
    public void setAnulada(boolean anulada) {
        this.anulada = anulada;
    }
    public Date getFecha() {
        return fecha;
    }
    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }
    
    public void agregarDetalle(DetalleFactura detalleNuevo){
        this.detalles.add(detalleNuevo);
        detalleNuevo.setFactura(this);
    }
    
    public double getTotalFactura(){
        double totalFactura = 0;
        for (DetalleFactura d : detalles) {
            totalFactura += d.getSubTotal();
        }
        return totalFactura;
    }    
}
