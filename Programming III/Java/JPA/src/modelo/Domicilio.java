/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "domicilio")
public class Domicilio extends EntityBean{    
    private int idDomicilio;
    private String localidad;
    private String calle;
    private int numero;
    private Persona persona;
    
    public Domicilio() {
    }

    public Domicilio(String localidad, String calle, int numero) {        
        this.localidad = localidad;
        this.calle = calle;
        this.numero = numero;
    }
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getIdDomicilio() {
        return idDomicilio;
    }
    public void setIdDomicilio(int idDomicilio) {
        this.idDomicilio = idDomicilio;
    }
    public String getLocalidad() {
        return localidad;
    }
    public void setLocalidad(String localidad) {
        this.localidad = localidad;
    }
    public String getCalle() {
        return calle;
    }
    public void setCalle(String calle) {
        this.calle = calle;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }    
    @OneToOne(mappedBy = "domicilio")
    public Persona getPersona() {
        return persona;
    }
    public void setPersona(Persona persona) {
        this.persona = persona;
    }    
}
