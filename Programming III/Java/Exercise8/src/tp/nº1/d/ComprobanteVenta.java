/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.d;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class ComprobanteVenta {
    
    private String tipo;
    private Date fecha;    
    private int numero;
    private double total;
    private List<DetalleCompVenta> refDetalleCompVenta;
    private Cliente refCliente;

    public ComprobanteVenta() {
    }

    public ComprobanteVenta(String tipo, Date fecha, int numero) {
        this.tipo = tipo;
        this.fecha = fecha;
        this.numero = numero;        
        this.refDetalleCompVenta = new ArrayList();
    }  

    public List<DetalleCompVenta> getRefDetalleCompVenta() {
        return refDetalleCompVenta;
    }
    public void setRefDetalleCompVenta(List<DetalleCompVenta> refDetalleCompVenta) {
        this.refDetalleCompVenta = refDetalleCompVenta;
    }
    public Cliente getRefCliente() {
        return refCliente;
    }
    public void setRefCliente(Cliente refCliente) {
        this.refCliente = refCliente;
    }   
    public double getTotal() {
        return total;
    }
    public void setTotal(double total) {
        this.total = total;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }
    public Date getFecha() {
        return fecha;
    }
    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public void agregarDetalle(DetalleCompVenta detalleNuevo){
        this.refDetalleCompVenta.add(detalleNuevo);
        detalleNuevo.setRefComprobanteVenta(this);
    }
    
    public void calcularTotal(){
        if (this.refDetalleCompVenta != null) {
            for (DetalleCompVenta d : refDetalleCompVenta) {
                this.total += d.calcularSubTotal();
            }
        }
    }
   
}
