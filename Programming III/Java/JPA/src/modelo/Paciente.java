/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.ArrayList;
import java.util.List;
import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */

@Entity
@Table(name = "paciente")
public class Paciente extends Persona{
    
    private int nroSocio;
    private List<Turno> turnos;
    private HistoriaClinica historiaClinica;
    
    public Paciente() {
    }

    public Paciente(int nroSocio, String nombre, String apellido, long dni) {
        super(nombre, apellido, dni);        
        this.nroSocio = nroSocio;
    }

    public int getNroSocio() {
        return nroSocio;
    }
    public void setNroSocio(int nroSocio) {
        this.nroSocio = nroSocio;
    }
    @OneToMany(mappedBy = "paciente", cascade = CascadeType.ALL)
    public List<Turno> getTurnos() {
        return turnos;
    }
    public void setTurnos(List<Turno> turnos) {
        this.turnos = turnos;
    }   
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "idHistoriaClinica")
    public HistoriaClinica getHistoriaClinica() {
        return historiaClinica;
    }
    public void setHistoriaClinica(HistoriaClinica historiaClinica) {
        this.historiaClinica = historiaClinica;
    } 
                
}
