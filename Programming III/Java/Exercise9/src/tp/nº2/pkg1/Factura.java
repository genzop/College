/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº2.pkg1;

import java.util.ArrayList;
import java.util.Date;
import javax.swing.JOptionPane;

/**
 *
 * @author Enzo
 */
public class Factura {
    
    private Date fecha;        
    private long numero;    
    private double total;
    private Cliente refCliente;
    private ArrayList<FacturaDetalle> refFacturaDetalle;

    public Factura() {
    }

    public Factura(Date fecha, long numero, double total, int cantFacturaDetalle, ArrayList<Articulo> articulos) {
        this.fecha = fecha;
        this.numero = numero;
        this.total = total;
        this.refFacturaDetalle = new ArrayList();
        
        for (int i = 0; i < cantFacturaDetalle; i++) {
           String auxCantidad = JOptionPane.showInputDialog("Ingrese la cantidad del " + (i+1) + "º articulo:");
           int cantidad = Integer.parseInt(auxCantidad);
           
           FacturaDetalle detalle = new FacturaDetalle(cantidad);
           detalle.setRefFactura(this);
           detalle.setRefArticulo(articulos.get(i));
           articulos.get(i).getRefFacturaDetalle().add(detalle);
           this.refFacturaDetalle.add(detalle);                   
        }        
    }

    public Cliente getRefCliente() {
        return refCliente;
    }
    public void setRefCliente(Cliente refCliente) {
        this.refCliente = refCliente;
    }
    public ArrayList<FacturaDetalle> getRefFacturaDetalle() {
        return refFacturaDetalle;
    }
    public void setRefFacturaDetalle(ArrayList<FacturaDetalle> refFacturaDetalle) {
        this.refFacturaDetalle = refFacturaDetalle;
    }   
    public double getTotal() {
        return total;
    }
    public void setTotal(double total) {
        this.total = total;
    }
    public long getNumero() {
        return numero;
    }
    public void setNumero(long numero) {
        this.numero = numero;
    }
    public Date getFecha() {
        return fecha;
    }
    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    
}
