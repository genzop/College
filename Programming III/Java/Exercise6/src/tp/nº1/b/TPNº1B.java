/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.b;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class TPNº1B {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Empleado empleado1 = new Empleado("Enzo", 38909857, "Juan Jufre 2218", "genzop@gmail.com");
        RegimenHorario regimen1 = new RegimenHorario(1, 8, 0, 16, 0);
        
        Date fecha1 = new Date(2015, 6, 11);
        Date fecha2 = new Date(2015, 6, 12);
        Date fecha3 = new Date(2015, 7, 13);
        Date fecha4 = new Date(2015, 7, 14);
        Date fecha5 = new Date(2016, 6, 15);
        Date fecha6 = new Date(2016, 7, 16);
        Date fecha7 = new Date(2016, 7, 17);
        Date fecha8 = new Date(2016, 7, 18);
        
        Asistencia asist1 = new Asistencia(1, "Diaria", fecha1, 8, 10);
        Asistencia asist2 = new Asistencia(1, "Diaria", fecha2, 8, 20);
        Asistencia asist3 = new Asistencia(1, "Diaria", fecha3, 8, 0);
        Asistencia asist4 = new Asistencia(1, "Diaria", fecha4, 8, 20);
        Asistencia asist5 = new Asistencia(1, "Diaria", fecha5, 8, 0);
        Asistencia asist6 = new Asistencia(1, "Diaria", fecha6, 8, 35);
        Asistencia asist7 = new Asistencia(1, "Diaria", fecha7, 8, 20);
        Asistencia asist8 = new Asistencia(1, "Diaria", fecha8, 8, 0);
        
        empleado1.agregarRegimenHorario(regimen1);
        empleado1.agregarAsistencia(asist1);
        empleado1.agregarAsistencia(asist2);
        empleado1.agregarAsistencia(asist3);
        empleado1.agregarAsistencia(asist4);
        empleado1.agregarAsistencia(asist5);
        empleado1.agregarAsistencia(asist6);
        empleado1.agregarAsistencia(asist7);
        empleado1.agregarAsistencia(asist8);
        
        List<Asistencia> asistencias = new ArrayList();
        asistencias = empleado1.getAsistenciaXMesXAnio(7, 2016);
        
        for (Asistencia a : asistencias) {
            System.out.println("Asistencia: " + a.getFecha().getDate());
        }
        
        List<Tardanza> tardanzas = new ArrayList();
        tardanzas = empleado1.getDiasConTardanza(7, 2016);
        
        for (Tardanza t : tardanzas) {
            System.out.println("Tardanza: " + t.getFecha().getDate());
        }
        
       
        
        
        
        
        
    }
    
}
