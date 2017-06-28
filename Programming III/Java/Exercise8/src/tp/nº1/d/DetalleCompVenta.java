/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.d;

/**
 *
 * @author Enzo
 */
public class DetalleCompVenta {
    
    private int id;
    private int cantidad;
    private ComprobanteVenta refComprobanteVenta;
    private Articulo refArticulo;

    public DetalleCompVenta() {
    }

    public DetalleCompVenta(int id, int cantidad, Articulo articulo) {
        this.id = id;
        this.cantidad = cantidad;
        this.refArticulo = articulo;
        articulo.getRefDetalleCompVenta().add(this);
    }

    public ComprobanteVenta getRefComprobanteVenta() {
        return refComprobanteVenta;
    }
    public void setRefComprobanteVenta(ComprobanteVenta refComprobanteVenta) {
        this.refComprobanteVenta = refComprobanteVenta;
    }
    public Articulo getRefArticulo() {
        return refArticulo;
    }
    public void setRefArticulo(Articulo refArticulo) {
        this.refArticulo = refArticulo;
    }    
    public int getCantidad() {
        return cantidad;
    }
    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
           
    public double calcularSubTotal(){
        return this.cantidad * this.getRefArticulo().getPrecio();
    }

    
}
