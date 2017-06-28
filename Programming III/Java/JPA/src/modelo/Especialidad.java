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
import javax.persistence.ManyToMany;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */

@Entity
@Table(name = "especialidad")
public class Especialidad extends EntityBean{
    
    private int idEspecialidad;
    private String denominacion;
    private List<Medico> medicos;
    
    public Especialidad() {
        this.medicos = new ArrayList();
    }

    public Especialidad(String denominacion) {        
        this.denominacion = denominacion;
        this.medicos = new ArrayList();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getIdEspecialidad() {
        return idEspecialidad;
    }
    public void setIdEspecialidad(int idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
    }
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }
    @ManyToMany(mappedBy = "especialidades", cascade = CascadeType.ALL)
    public List<Medico> getMedicos() {
        return medicos;
    }
    public void setMedicos(List<Medico> medicos) {
        this.medicos = medicos;
    }      
}
