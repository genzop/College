/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.b;

/**
 *
 * @author Enzo
 */
public class RegimenHorario {
       
    private long id;        
    private int horaIngreso;    
    private int minutoIngreso;    
    private int horaEgreso;    
    private int minutoEgreso;
    private Empleado refEmpleado;

    public RegimenHorario() {
    }

    public RegimenHorario(long id, int horaIngreso, int minutoIngreso, int horaEgreso, int minutoEgreso) {
        this.id = id;
        this.horaIngreso = horaIngreso;
        this.minutoIngreso = minutoIngreso;
        this.horaEgreso = horaEgreso;
        this.minutoEgreso = minutoEgreso;
    }

    public Empleado getRefEmpleado() {
        return refEmpleado;
    }
    public void setRefEmpleado(Empleado refEmpleado) {
        this.refEmpleado = refEmpleado;
    }            
    public int getMinutoEgreso() {
        return minutoEgreso;
    }
    public void setMinutoEgreso(int minutoEgreso) {
        this.minutoEgreso = minutoEgreso;
    }
    public int getHoraEgreso() {
        return horaEgreso;
    }
    public void setHoraEgreso(int horaEgreso) {
        this.horaEgreso = horaEgreso;
    }
    public int getMinutoIngreso() {
        return minutoIngreso;
    }
    public void setMinutoIngreso(int minutoIngreso) {
        this.minutoIngreso = minutoIngreso;
    }
    public int getHoraIngreso() {
        return horaIngreso;
    }
    public void setHoraIngreso(int horaIngreso) {
        this.horaIngreso = horaIngreso;
    }
    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }

    
}
