/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package orm;
import controlador.GestorHistoriaClinica;
import modelo.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Enzo
 */

public class Main {

    public static void main(String[] args) {
        
        try {
            GestorHistoriaClinica gestor = new GestorHistoriaClinica();
            Date fecha1 = new Date(2016, 8, 9);
            Date fecha2 = new Date(2016, 11, 12);
            
            Domicilio dom2 = new Domicilio("Mendoza", "Calle de los empleados", 555);
            Domicilio dom3 = new Domicilio("Mendoza", "Calle de los pacientes", 555);
            
            Domicilio dom1 = new Domicilio("Mendoza", "Calle de los medicos", 555);
            Especialidad esp1 = new Especialidad("Cirujano");
            Especialidad esp2 = new Especialidad("Pediatra");
            ArrayList<Especialidad> especialidades = new ArrayList();
            especialidades.add(esp1);
            especialidades.add(esp2);
            Turno turno1 = new Turno(fecha1, 16, 0);           
            Turno turno2 = new Turno(fecha2, 20, 0);
            ArrayList<Turno> turnos = new ArrayList();
            turnos.add(turno1);
            turnos.add(turno2);
            Medico medico = new Medico(2654851, 156874892, "Jorge", "Perez", 38909854);
            medico.setEspecialidades(especialidades);
            medico.setTurnos(turnos);
            medico.setDomicilio(dom1);
            
            esp1.getMedicos().add(medico);
            esp2.getMedicos().add(medico);
            
            Empleado empleado = new Empleado(235487, 1, "Martin", "Ramirez", 12548773);
            empleado.setDomicilio(dom2);
            
            DetalleHistoriaClinica detalle1 = new DetalleHistoriaClinica(fecha1, "Dolor de cabeza", "Migraña", "Ninguna");
            DetalleHistoriaClinica detalle2 = new DetalleHistoriaClinica(fecha2, "Vomito", "Gastroenteritis", "Internado");
            ArrayList<DetalleHistoriaClinica> detalles = new ArrayList();
            detalles.add(detalle1);
            detalles.add(detalle2);
            HistoriaClinica historia = new HistoriaClinica(355489, fecha1);
            historia.setDetalles(detalles);
            Paciente paciente = new Paciente(354871, "Juan", "Gonzales", 57483651);            
            paciente.setHistoriaClinica(historia);
            paciente.setTurnos(turnos);
            paciente.setDomicilio(dom3);    
            
            detalle1.setHistoriaClinica(historia);
            detalle2.setHistoriaClinica(historia);
            
            turno1.setMedico(medico);
            turno2.setMedico(medico);
            turno1.setPaciente(paciente);
            turno2.setPaciente(paciente);
          
            gestor.guardar(paciente);
            gestor.guardar(empleado);
            
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
