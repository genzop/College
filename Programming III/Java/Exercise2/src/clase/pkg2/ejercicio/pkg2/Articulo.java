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
public class Articulo {
    
    private double precio;    
    private String nombre;
    private String codigo;
    private ArrayList<DetalleFactura> detalleCantidad;

    public Articulo() {
    }

    public Articulo(double precio, String nombre, String codigo) {
        this.precio = precio;
        this.nombre = nombre;
        this.codigo = codigo;
        this.detalleCantidad = new ArrayList();
    }   

    public ArrayList<DetalleFactura> getDetalleCantidad() {
        return detalleCantidad;
    }
    public void setDetalleCantidad(ArrayList<DetalleFactura> detalleCantidad) {
        this.detalleCantidad = detalleCantidad;
    }    
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public String getCodigo() {
        return codigo;
    }
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }
    public double getPrecio() {
        return precio;
    }
    public void setPrecio(double precio) {
        this.precio = precio;
    }

}
