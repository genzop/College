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
public class Articulo {
    
    private int nombre;        
    private double precio;
    private ArrayList<FacturaDetalle> refFacturaDetalle;

    public Articulo() {
    }

    public Articulo(int nombre, double precio) {
        this.nombre = nombre;
        this.precio = precio;
        this.refFacturaDetalle = new ArrayList();
    }

    public ArrayList<FacturaDetalle> getRefFacturaDetalle() {
        return refFacturaDetalle;
    }
    public void setRefFacturaDetalle(ArrayList<FacturaDetalle> refFacturaDetalle) {
        this.refFacturaDetalle = refFacturaDetalle;
    }    
    public double getPrecio() {
        return precio;
    }
    public void setPrecio(double precio) {
        this.precio = precio;
    }
    public int getNombre() {
        return nombre;
    }
    public void setNombre(int nombre) {
        this.nombre = nombre;
    }
   
}
