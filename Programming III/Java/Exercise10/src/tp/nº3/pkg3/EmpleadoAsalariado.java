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
public class EmpleadoAsalariado extends Empleado{
    
    private double salarioSemana;

    public EmpleadoAsalariado() {
    }

    public EmpleadoAsalariado(double salarioSemana, String apellido, String nombre, long dni, long id, Date fechaAlta, Date fechaBaja) {
        super(apellido, nombre, dni, id, fechaAlta, fechaBaja);
        this.salarioSemana = salarioSemana;
    }   

    public double getSalarioSemana() {
        return salarioSemana;
    }
    public void setSalarioSemana(double salarioSemana) {
        this.salarioSemana = salarioSemana;
    }

    @Override
    public double ingresosEmpleado() {
        return this.salarioSemana;
    }
}
