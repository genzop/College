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
public class EmpleadoPorHoras extends Empleado{
    
    private double montoHora;        
    private double horasTrabajadas;

    public EmpleadoPorHoras() {
    }

    public EmpleadoPorHoras(double montoHora, double horasTrabajadas, String apellido, String nombre, long dni, long id, Date fechaAlta, Date fechaBaja) {
        super(apellido, nombre, dni, id, fechaAlta, fechaBaja);
        this.montoHora = montoHora;
        this.horasTrabajadas = horasTrabajadas;
    }   

    public double getHorasTrabajadas() {
        return horasTrabajadas;
    }
    public void setHorasTrabajadas(double horasTrabajadas) {
        this.horasTrabajadas = horasTrabajadas;
    }
    public double getMontoHora() {
        return montoHora;
    }
    public void setMontoHora(double montoHora) {
        this.montoHora = montoHora;
    }    

    @Override
    public double ingresosEmpleado() {
        return this.montoHora * this.horasTrabajadas;
    }
}
