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
public class EmpleadoPorComision extends Empleado{
    
    private double ventasTotales;        
    private double tasaComision;

    public EmpleadoPorComision() {
    }

    public EmpleadoPorComision(double ventasTotales, double tasaComision, String apellido, String nombre, long dni, long id, Date fechaAlta, Date fechaBaja) {
        super(apellido, nombre, dni, id, fechaAlta, fechaBaja);
        this.ventasTotales = ventasTotales;
        this.tasaComision = tasaComision;
    }
      
    public double getTasaComision() {
        return tasaComision;
    }
    public void setTasaComision(double tasaComision) {
        this.tasaComision = tasaComision;
    }
    public double getVentasTotales() {
        return ventasTotales;
    }
    public void setVentasTotales(double ventasTotales) {
        this.ventasTotales = ventasTotales;
    }

    @Override
    public double ingresosEmpleado() {
        return this.ventasTotales * this.tasaComision;
    }   
}
