/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº3.pkg3;

import java.util.Date;

/**
 *
 * @author Enzo
 */
public abstract class Empleado extends EntityID{
    
    private String apellido;        
    private String nombre;
    private long dni;

    public Empleado() {
    }
    
    public Empleado(String apellido, String nombre, long dni, long id, Date fechaAlta, Date fechaBaja) {
        super(id, fechaAlta, fechaBaja);
        this.apellido = apellido;
        this.nombre = nombre;
        this.dni = dni;
    }
    
    public long getDni() {
        return dni;
    }
    public void setDni(long dni) {
        this.dni = dni;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public String getApellido() {
        return apellido;
    }
    public void setApellido(String apellido) {
        this.apellido = apellido;
    }    
    
    public abstract double ingresosEmpleado();
}
