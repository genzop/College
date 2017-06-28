/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg2.ejercicio.pkg2;

/**
 *
 * @author Enzo
 */
public class DetalleFactura {
    
    private int cantidad;
    private Factura factura;
    private Articulo articulo;

    public DetalleFactura() {
    }
    
    public DetalleFactura(int cantidad) {
        this.cantidad = cantidad;
    }   

    public Factura getFactura() {
        return factura;
    }
    public void setFactura(Factura factura) {
        this.factura = factura;
    }
    public Articulo getArticulo() {
        return articulo;
    }
    public void setArticulo(Articulo articulo) {
        this.articulo = articulo;
    }
    public int getCantidad() {
        return cantidad;
    }
    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }
    
    public void agregarArticulo(Articulo articuloNuevo){
        this.articulo = articuloNuevo;
        articuloNuevo.getDetalleCantidad().add(this);
    }

    public double getSubTotal(){
        return this.cantidad * articulo.getPrecio();
    }
}