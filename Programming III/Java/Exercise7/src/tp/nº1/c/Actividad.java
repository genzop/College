/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.c;

import java.util.Date;

/**
 *
 * @author Enzo
 */
public class Actividad {
    
    private Date fechaInicio;
    private Date fechaFin;
    private String nombre;
    private String descripcion;
    private TipoActividad refTipoActividad;
    private Persona refPersona;

    public Actividad() {
    }

    public Actividad(Date fechaInicio, Date fechaFin, String nombre, String descripcion) {
        this.fechaInicio = fechaInicio;
        this.fechaFin = fechaFin;
        this.nombre = nombre;
        this.descripcion = descripcion;
    } 

    public TipoActividad getRefTipoActividad() {
        return refTipoActividad;
    }
    public void setRefTipoActividad(TipoActividad refTipoActividad) {
        this.refTipoActividad = refTipoActividad;
    }
    public Persona getRefPersona() {
        return refPersona;
    }
    public void setRefPersona(Persona refPersona) {
        this.refPersona = refPersona;
    }   
    public String getDescripcion() {
        return descripcion;
    }
    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }    
    public Date getFechaFin() {
        return fechaFin;
    }
    public void setFechaFin(Date fechaFin) {
        this.fechaFin = fechaFin;
    }
    public Date getFechaInicio() {
        return fechaInicio;
    }
    public void setFechaInicio(Date fechaInicio) {
        this.fechaInicio = fechaInicio;
    }
    
    public void asignarTipoDeActividad (TipoActividad tipoDeActividad){
        this.setRefTipoActividad(tipoDeActividad);
        tipoDeActividad.getRefActividad().add(this);
    }
    
}
