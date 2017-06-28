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
public class Sector {
    
    private int numero;        
    private String denominacion;    
    private String tipo;
    private List<Persona> refPersona;
    private List<Sector> sectorInferior;
    private Sector sectorSuperior;

    public Sector() {
    }

    public Sector(int numero, String denominacion, String tipo) {
        this.numero = numero;
        this.denominacion = denominacion;
        this.tipo = tipo;
        this.refPersona = new ArrayList();
        this.sectorInferior = new ArrayList();
    }

    public Sector getSectorSuperior() {
        return sectorSuperior;
    }
    public void setSectorSuperior(Sector sectorSuperior) {
        this.sectorSuperior = sectorSuperior;
    }    
    public List<Persona> getRefPersona() {
        return refPersona;
    }
    public void setRefPersona(List<Persona> refPersona) {
        this.refPersona = refPersona;
    }
    public List<Sector> getSectorInferior() {
        return sectorInferior;
    }
    public void setSectorInferior(List<Sector> sectorInferior) {
        this.sectorInferior = sectorInferior;
    }    
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }    
    
    public void asignarSubsector(Sector subsector){
        this.sectorInferior.add(subsector);
        subsector.setSectorSuperior(this);
    }
    
    public List<Sector> obtenerTotalSubsectores(Sector raiz, List<Sector> acumulador){
        acumulador.add(raiz);
        if (raiz.denominacion != null && raiz.sectorInferior != null) {
            for (Sector s : raiz.sectorInferior) {
                acumulador = obtenerTotalSubsectores(s, acumulador);
            }
        }        
        return acumulador;
    }
}
