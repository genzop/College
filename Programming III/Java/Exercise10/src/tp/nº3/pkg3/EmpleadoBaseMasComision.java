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
public class EmpleadoBaseMasComision extends EmpleadoPorComision{
    
    private double salarioBase;

    public EmpleadoBaseMasComision() {
    }

    public EmpleadoBaseMasComision(double salarioBase, double ventasTotales, double tasaComision, String apellido, String nombre, long dni, long id, Date fechaAlta, Date fechaBaja) {
        super(ventasTotales, tasaComision, apellido, nombre, dni, id, fechaAlta, fechaBaja);
        this.salarioBase = salarioBase;
    }
    
    public double getSalarioBase() {
        return salarioBase;
    }
    public void setSalarioBase(double salarioBase) {
        this.salarioBase = salarioBase;
    }
    
    @Override
    public double ingresosEmpleado() {
        return this.salarioBase + super.ingresosEmpleado();
    }   
}
