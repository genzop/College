/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;
import javax.persistence.Transient;

/**
 *
 * @author Enzo
 */

@Entity
@Table(name = "historiaClinica")
public class HistoriaClinica extends EntityBean{
    
    private int idHistoriaClinica;
    private int numero;
    private Date fecha;
    private Paciente paciente;
    private List<DetalleHistoriaClinica> detalles;

    public HistoriaClinica() {
        this.detalles = new ArrayList();
    }

    public HistoriaClinica(int numero, Date fecha) {
        this.numero = numero;
        this.fecha = fecha;
        this.detalles = new ArrayList();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getIdHistoriaClinica() {
        return idHistoriaClinica;
    }
    public void setIdHistoriaClinica(int idHistoriaClinica) {
        this.idHistoriaClinica = idHistoriaClinica;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }
    @Transient
    public Date getFecha() {
        return fecha;
    }
    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
    @OneToOne(mappedBy = "historiaClinica")
    public Paciente getPaciente() {
        return paciente;
    }
    public void setPaciente(Paciente paciente) {
        this.paciente = paciente;
    }
    @OneToMany(mappedBy = "historiaClinica", cascade = CascadeType.ALL)
    public List<DetalleHistoriaClinica> getDetalles() {
        return detalles;
    }
    public void setDetalles(List<DetalleHistoriaClinica> detalles) {
        this.detalles = detalles;
    }
    
}
