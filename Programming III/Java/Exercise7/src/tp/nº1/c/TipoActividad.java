/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.c;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class TipoActividad {
    
    private int codigo;        
    private String denominacion;    
    private double puntosAsignados;
    private List<Actividad> refActividad;

    public TipoActividad() {
    }

    public TipoActividad(int codigo, String denominacion, double puntosAsignados) {
        this.codigo = codigo;
        this.denominacion = denominacion;
        this.puntosAsignados = puntosAsignados;
        this.refActividad = new ArrayList();
    }

    public List<Actividad> getRefActividad() {
        return refActividad;
    }
    public void setRefActividad(List<Actividad> refActividad) {
        this.refActividad = refActividad;
    }   
    public double getPuntosAsignados() {
        return puntosAsignados;
    }
    public void setPuntosAsignados(double puntosAsignados) {
        this.puntosAsignados = puntosAsignados;
    }
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }
    public int getCodigo() {
        return codigo;
    }
    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }    
}
