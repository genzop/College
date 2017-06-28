/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.c;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class TPNº1C {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        TipoActividad tipo1 = new TipoActividad(13, "Informaticas", 10);
        TipoActividad tipo2 = new TipoActividad(7, "Administrativas", 5);
        Date fechaInicio = new Date(2016, 7, 8);
        Date fechaFin = new Date(2016, 10, 25);
        Actividad act1 = new Actividad(fechaInicio, fechaFin, "Programacion III", "Materia semestral");
        Actividad act2 = new Actividad(fechaInicio, fechaFin, "Laboratorio III", "Materia semestral");
        Actividad act3 = new Actividad(fechaInicio, fechaFin, "Organizacion Empresarial", "Materia semestral");
        Persona persona1 = new Persona("Enzo Panettieri", "DNI", 38909857, 4458818, "genzop@gmail.com", "155018675");
        
        
        act1.asignarTipoDeActividad(tipo1);
        act2.asignarTipoDeActividad(tipo1);
        act3.asignarTipoDeActividad(tipo2);
        
        persona1.agregarActividad(act1);
        persona1.agregarActividad(act2);
        persona1.agregarActividad(act3);
        
        System.out.println(persona1.totalPuntosAsignados(38909857));
        System.out.println(persona1.totalPuntosAsignados(38909857, 7));
        System.out.println(persona1.totalPuntosAsignados(38909857, 13, 2015));
        
        Sector sector1 = new Sector(3, "UTN", "Universidad");
        Sector sector2 = new Sector(3, "Sistemas", "Departamento");
        Sector sector3 = new Sector(3, "Electronico", "Departamento");
        Sector sector4 = new Sector(3, "Tecnicatura", "Carrera");
        Sector sector5 = new Sector(3, "Ingenieria", "Carrera");
        
        sector1.asignarSubsector(sector2);
        sector1.asignarSubsector(sector3);
        sector2.asignarSubsector(sector4);
        sector3.asignarSubsector(sector5);
        
        List<Sector> subsectores = new ArrayList();
        subsectores = sector1.obtenerTotalSubsectores(sector2, subsectores);
        for (Sector s : subsectores) {
            System.out.println(s.getDenominacion());
        }
        
        
        
                
        
        
    }
    
}
