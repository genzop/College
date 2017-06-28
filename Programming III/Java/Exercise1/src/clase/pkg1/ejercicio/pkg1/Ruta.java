/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg1.ejercicio.pkg1;

import java.util.ArrayList;

/**
 *
 * @author Enzo
 */
public class Ruta {
    
    private String nombre;
    private ArrayList<TramoRuta> tramos;

    public Ruta() {
    }       

    public Ruta(String nombre) {
        this.nombre = nombre;
        tramos = new ArrayList();
    }    

    public ArrayList<TramoRuta> getTramos() {
        return tramos;
    }
    public void setTramos(ArrayList<TramoRuta> tramos) {
        this.tramos = tramos;
    }   
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public void agregarTramo(TramoRuta tramoNuevo){
        this.tramos.add(tramoNuevo);
        tramoNuevo.setRutaPrincipal(this);
    }    
    
    public int calcularTotalKmRuta(){
        int totalKmRuta = 0;
        if (tramos != null) {
            for (TramoRuta t : tramos) {
                totalKmRuta += t.getCantKm();
            }            
        }    
        return totalKmRuta;
    }
}
