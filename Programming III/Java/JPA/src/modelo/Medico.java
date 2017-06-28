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
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "medico")
public class Medico extends Persona{    
    
    private int matricula;
    private long celular;
    private List<Especialidad> especialidades;
    private List<Turno> turnos;

    public Medico() {
        
    }

    public Medico(int matricula, long celular, String nombre, String apellido, long dni) {
        super(nombre, apellido, dni);        
        this.matricula = matricula;
        this.celular = celular;             
    }      
  
    public int getMatricula() {
        return matricula;
    }
    public void setMatricula(int matricula) {
        this.matricula = matricula;
    }
    public long getCelular() {
        return celular;
    }
    public void setCelular(long celular) {
        this.celular = celular;
    }    
    @ManyToMany(cascade = CascadeType.ALL)
    @JoinTable(name = "medico_especialidad", 
               joinColumns = @JoinColumn(name = "idMedico"), 
               inverseJoinColumns = @JoinColumn(name = "idEspecialidad"))
    public List<Especialidad> getEspecialidades() {
        return especialidades;
    }
    public void setEspecialidades(List<Especialidad> especialidades) {
        this.especialidades = especialidades;
    }
    @OneToMany(mappedBy = "medico")
    public List<Turno> getTurnos() {
        return turnos;
    }
    public void setTurnos(List<Turno> turnos) {
        this.turnos = turnos;
    }    
}
