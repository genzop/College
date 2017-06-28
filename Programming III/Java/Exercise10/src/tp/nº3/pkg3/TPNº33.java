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
public class TPNº33 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Date fecha1 = new Date(2015, 7, 5);
        Date fecha2 = new Date(2017, 6, 30);
        EmpleadoAsalariado empAsal = new EmpleadoAsalariado(3000, "Panettieri", "Enzo", 38909857, 42383, fecha1, fecha2);
        System.out.println(empAsal.ingresosEmpleado());
        EmpleadoPorComision empXCom = new EmpleadoPorComision(15000, 0.10, "Panettieri", "Luigi", 40102193, 42382, fecha1, fecha2);
        System.out.println(empXCom.ingresosEmpleado());
        EmpleadoPorHoras empXHoras = new EmpleadoPorHoras(20, 60, "Herrero", "Pedro", 36487812, 41683, fecha1, fecha2);
        System.out.println(empXHoras.ingresosEmpleado());
        EmpleadoBaseMasComision empBaseCom = new EmpleadoBaseMasComision(6000, 10000, 0.10, "Ruiz", "Andres", 31884568, 43875, fecha1, fecha2);
        System.out.println(empBaseCom.ingresosEmpleado());
    }
    
}
