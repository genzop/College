/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import bsh.This;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */

@Entity
@Table(name = "empleado")
public class Empleado extends Persona{

    private int nroLegajo;
    private double sueldo;

    public Empleado() {
    }

    public Empleado(int nroLegajo, double sueldo, String nombre, String apellido, long dni) {
        super(nombre, apellido, dni);        
        this.nroLegajo = nroLegajo;
        this.sueldo = sueldo;
    }

    public int getNroLegajo() {
        return nroLegajo;
    }
    public void setNroLegajo(int nroLegajo) {
        this.nroLegajo = nroLegajo;
    }
    public double getSueldo() {
        return sueldo;
    }
    public void setSueldo(double sueldo) {
        this.sueldo = sueldo;
    }   
    
}
