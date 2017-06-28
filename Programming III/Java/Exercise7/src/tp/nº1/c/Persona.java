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
public class Persona {
    
    private String nombre;        
    private String tipoDocumento;    
    private long nroDocumento;
    private int telefono;        
    private String email;    
    private String celular;
    private List<Actividad> refActividad;
    private Sector refSector;

    public Persona() {
    }

    public Persona(String nombre, String tipoDocumento, long nroDocumento, int telefono, String email, String celular) {
        this.nombre = nombre;
        this.tipoDocumento = tipoDocumento;
        this.nroDocumento = nroDocumento;
        this.telefono = telefono;
        this.email = email;
        this.celular = celular;
        this.refActividad = new ArrayList();
    }

    public Sector getRefSector() {
        return refSector;
    }
    public void setRefSector(Sector refSector) {
        this.refSector = refSector;
    }    
    public List<Actividad> getRefActividad() {
        return refActividad;
    }
    public void setRefActividad(List<Actividad> refActividad) {
        this.refActividad = refActividad;
    }   
    public String getCelular() {
        return celular;
    }
    public void setCelular(String celular) {
        this.celular = celular;
    }
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    public int getTelefono() {
        return telefono;
    }
    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }
    public long getNroDocumento() {
        return nroDocumento;
    }
    public void setNroDocumento(long nroDocumento) {
        this.nroDocumento = nroDocumento;
    }
    public String getTipoDocumento() {
        return tipoDocumento;
    }    
    public void setTipoDocumento(String tipoDocumento) {
        this.tipoDocumento = tipoDocumento;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public void agregarActividad(Actividad actividadNueva){
        this.refActividad.add(actividadNueva);
        actividadNueva.setRefPersona(this);
    }
    
    public double totalPuntosAsignados(long nroDocumento){
        double puntosAsignados = 0;        
        if (nroDocumento == this.nroDocumento && refActividad != null) {
            for (Actividad a : refActividad) {
                puntosAsignados += a.getRefTipoActividad().getPuntosAsignados();
            }
        }
        return puntosAsignados;
    }
    
    public double totalPuntosAsignados(long nroDocumento, int codigo){
        double puntosAsignados = 0;      
        if (nroDocumento == this.nroDocumento && refActividad != null) {
            for (Actividad a : refActividad) {
                if (codigo == a.getRefTipoActividad().getCodigo()) {
                    puntosAsignados += a.getRefTipoActividad().getPuntosAsignados();
                }                
            }
        }
        return puntosAsignados;
    }
    
    public double totalPuntosAsignados(long nroDocumento, int codigo, int anio){
        double puntosAsignados = 0;
        if (nroDocumento == this.nroDocumento && refActividad != null) {
            for (Actividad a : refActividad) {
                if (codigo == a.getRefTipoActividad().getCodigo() && anio == a.getFechaInicio().getYear()) {
                    puntosAsignados += a.getRefTipoActividad().getPuntosAsignados();
                }                
            }
        }
        return puntosAsignados;
    }
}
