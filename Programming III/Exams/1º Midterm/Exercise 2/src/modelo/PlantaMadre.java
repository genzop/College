/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "Planta_Madre")
public class PlantaMadre extends EntityBean{
    
    private int hilera;
    private int nroDeOrden;
    private long codigo;
    private Cuadro cuadro;
    private Variedad variedad;

    public PlantaMadre() {
    }

    @Column(name = "Hilera")
    public int getHilera() {
        return hilera;
    }
    public void setHilera(int hilera) {
        this.hilera = hilera;
    }
    
    @Column(name = "Numero_de_Orden")
    public int getNroDeOrden() {
        return nroDeOrden;
    }
    public void setNroDeOrden(int nroDeOrden) {
        this.nroDeOrden = nroDeOrden;
    }

    @Id
    @GeneratedValue
    @Column(name = "Codigo")
    public long getCodigo() {
        return codigo;
    }
    public void setCodigo(long codigo) {
        this.codigo = codigo;
    }

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "ID_Cuadro")
    public Cuadro getCuadro() {
        return cuadro;
    }
    public void setCuadro(Cuadro cuadro) {
        this.cuadro = cuadro;
    }

    @ManyToOne(cascade = CascadeType.ALL) 
    @JoinColumn(name = "ID_Variedad")
    public Variedad getVariedad() {
        return variedad;
    }
    public void setVariedad(Variedad variedad) {
        this.variedad = variedad;
    }
    
    
}
