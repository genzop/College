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
public class FacturaDetalle {
    
    private int cantidad;
    private Factura refFactura;
    private Articulo refArticulo;

    public FacturaDetalle() {
    }

    public FacturaDetalle(int cantidad) {
        this.cantidad = cantidad;
    }   

    public Articulo getRefArticulo() {
        return refArticulo;
    }
    public void setRefArticulo(Articulo refArticulo) {
        this.refArticulo = refArticulo;
    }    
    public Factura getRefFactura() {
        return refFactura;
    }
    public void setRefFactura(Factura refFactura) {
        this.refFactura = refFactura;
    }    
    public int getCantidad() {
        return cantidad;
    }
    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }
    
}
