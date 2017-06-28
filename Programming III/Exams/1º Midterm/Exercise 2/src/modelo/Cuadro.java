/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.ArrayList;
import java.util.List;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "cuadro")
public class Cuadro extends EntityBean{
    
    private int nroCuadro;
    private double superficie;
    private int cantidadHileras;
    private int cantidadPlantasXHilera;
    private CampoComercial campoComercial;
    private List<PlantaMadre> plantasMadre;

    public Cuadro() {
        plantasMadre = new ArrayList<>();        
    }

    @Id
    @GeneratedValue
    @Column(name = "Numero")
    public int getNroCuadro() {
        return nroCuadro;
    }
    public void setNroCuadro(int nroCuadro) {
        this.nroCuadro = nroCuadro;
    }

    @Column(name = "Superficie")
    public double getSuperficie() {
        return superficie;
    }
    public void setSuperficie(double superficie) {
        this.superficie = superficie;
    }

    @Column(name = "Cantidad_de_Hileras")
    public int getCantidadHileras() {
        return cantidadHileras;
    }
    public void setCantidadHileras(int cantidadHileras) {
        this.cantidadHileras = cantidadHileras;
    }

    @Column(name = "Cantidad_de_Plantas_por_Hilera")
    public int getCantidadPlantasXHilera() {
        return cantidadPlantasXHilera;
    }
    public void setCantidadPlantasXHilera(int cantidadPlantasXHilera) {
        this.cantidadPlantasXHilera = cantidadPlantasXHilera;
    }

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "ID_Campo_Comercial")   
    public CampoComercial getCampoComercial() {
        return campoComercial;
    }
    public void setCampoComercial(CampoComercial campoComercial) {
        this.campoComercial = campoComercial;
    }

    @OneToMany(mappedBy = "cuadro")
    public List<PlantaMadre> getPlantasMadre() {
        return plantasMadre;
    }
    public void setPlantasMadre(List<PlantaMadre> plantasMadre) {
        this.plantasMadre = plantasMadre;
    }
    
    public int totalPlantasMadres(){
        return this.getPlantasMadre().size();
    }
    
}
