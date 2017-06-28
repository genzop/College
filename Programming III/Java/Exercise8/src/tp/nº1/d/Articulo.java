/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.d;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class Articulo {
    
    private int codigo;
    private String nombre;
    private double precio;
    private String rubro;
    private List<DetalleCompVenta> refDetalleCompVenta;

    public Articulo() {
    }

    public Articulo(int codigo, String nombre, double precio, String rubro) {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
        this.rubro = rubro;
        this.refDetalleCompVenta = new ArrayList();
    }

    public List<DetalleCompVenta> getRefDetalleCompVenta() {
        return refDetalleCompVenta;
    }
    public void setRefDetalleCompVenta(List<DetalleCompVenta> refDetalleCompVenta) {
        this.refDetalleCompVenta = refDetalleCompVenta;
    }    
    public String getRubro() {
        return rubro;
    }
    public void setRubro(String rubro) {
        this.rubro = rubro;
    }
    public double getPrecio() {
        return precio;
    }
    public void setPrecio(double precio) {
        this.precio = precio;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public int getCodigo() {
        return codigo;
    }
    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }
   
}
