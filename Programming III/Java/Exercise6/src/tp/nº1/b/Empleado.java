/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.b;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class Empleado {
    
    private String nombre;        
    private long cuit;    
    private String domicilio;    
    private String email;
    private List<Tardanza> refTardanza;
    private List<Asistencia> refAsistencia;
    private RegimenHorario refRegimenHorario;

    public Empleado() {
    }

    public Empleado(String nombre, long cuit, String domicilio, String email) {
        this.nombre = nombre;
        this.cuit = cuit;
        this.domicilio = domicilio;
        this.email = email;
        refTardanza = new ArrayList();
        refAsistencia = new ArrayList();
    }

    public List<Tardanza> getRefTardanza() {
        return refTardanza;
    }
    public void setRefTardanza(List<Tardanza> refTardanza) {
        this.refTardanza = refTardanza;
    }
    public List<Asistencia> getRefAsistencia() {
        return refAsistencia;
    }
    public void setRefAsistencia(List<Asistencia> refAsistencia) {
        this.refAsistencia = refAsistencia;
    }
    public RegimenHorario getRefRegimenHorario() {
        return refRegimenHorario;
    }
    public void setRefRegimenHorario(RegimenHorario refRegimenHorario) {
        this.refRegimenHorario = refRegimenHorario;
    }   
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    public String getDomicilio() {
        return domicilio;
    }
    public void setDomicilio(String domicilio) {
        this.domicilio = domicilio;
    }
    public long getCuit() {
        return cuit;
    }
    public void setCuit(long cuit) {
        this.cuit = cuit;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public void agregarAsistencia(Asistencia asistenciaNueva){
        this.refAsistencia.add(asistenciaNueva);
        asistenciaNueva.setRefEmpleado(this);        
    }
    
    public void agregarTardanza(Tardanza tardanzaNueva){
        this.refTardanza.add(tardanzaNueva);
        tardanzaNueva.setRefEmpleado(this);
    }
    
    public void agregarRegimenHorario(RegimenHorario regimenNuevo){
        this.setRefRegimenHorario(regimenNuevo);
        regimenNuevo.setRefEmpleado(this);
    }
    
    public List<Asistencia> getAsistenciaXMesXAnio(int mes, int anio){        
        List<Asistencia> asistenciaXMesXAnio = new ArrayList();
        if (this.refAsistencia != null) {
            for (Asistencia a : this.refAsistencia) {
                if (a.getFecha().getMonth() == mes && a.getFecha().getYear() == anio) {
                    asistenciaXMesXAnio.add(a);
                }                
            }
        }       
        return asistenciaXMesXAnio;
    }
    
    public List<Tardanza> getDiasConTardanza(int mes, int anio){
        List<Asistencia> asistenciasDelMesYAnio = new ArrayList();
        asistenciasDelMesYAnio = this.getAsistenciaXMesXAnio(mes, anio);
        if (this.refAsistencia != null) {
            for (Asistencia a : asistenciasDelMesYAnio) {
                if (a.getHora()*60 + a.getMinuto() > refRegimenHorario.getHoraIngreso()*60 + refRegimenHorario.getMinutoIngreso() + 15 ) {
                    Tardanza tardanza = new Tardanza(a.getId(), a.getTipo(), a.getFecha(), a.getHora(), a.getMinuto());
                    this.refTardanza.add(tardanza);
                }
            }
        }
        return this.refTardanza;
    }
}