/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.ArrayList;
import java.util.List;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "Variedad")
public class Variedad extends EntityBean{
    
    private String especie;
    private String denominacion;
    private String codigo;    
    private List<PlantaMadre> plantasMadre;

    public Variedad() {
        plantasMadre = new ArrayList<>();        
    }

    @Column(name = "Especie")
    public String getEspecie() {
        return especie;
    }
    public void setEspecie(String especie) {
        this.especie = especie;
    }

    @Column(name = "Denominacion")
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }

    @Id
    @Column(name = "Codigo")    
    public String getCodigo() {
        return codigo;
    }
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    @OneToMany(mappedBy = "variedad")
    public List<PlantaMadre> getPlantasMadre() {
        return plantasMadre;
    }
    public void setPlantasMadre(List<PlantaMadre> plantasMadre) {
        this.plantasMadre = plantasMadre;
    }
    
    
    
    
}
