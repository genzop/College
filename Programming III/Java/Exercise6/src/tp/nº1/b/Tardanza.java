/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.b;

import java.util.Date;

/**
 *
 * @author Enzo
 */
public class Tardanza {
    
    private long id;        
    private String tipo;    
    private Date fecha;
    private int hora;        
    private int minuto;
    private Empleado refEmpleado;

    public Tardanza() {
    }

    public Tardanza(long id, String tipo, Date fecha, int hora, int minuto) {
        this.id = id;
        this.tipo = tipo;
        this.fecha = fecha;
        this.hora = hora;
        this.minuto = minuto;
    }

    public Empleado getRefEmpleado() {
        return refEmpleado;
    }
    public void setRefEmpleado(Empleado refEmpleado) {
        this.refEmpleado = refEmpleado;
    }   
    public int getMinuto() {
        return minuto;
    }
    public void setMinuto(int minuto) {
        this.minuto = minuto;
    }
    public int getHora() {
        return hora;
    }
    public void setHora(int hora) {
        this.hora = hora;
    }
    public Date getFecha() {
        return fecha;
    }
    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }
    
    

}
