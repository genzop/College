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
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;

/**
 *
 * @author Enzo
 */
@Entity
@Table(name = "Campo_Comercial")
public class CampoComercial extends EntityBean{
    
    private int rut;
    private String denominacion;
    private String domicilio;
    private List<Cuadro> cuadros;

    public CampoComercial() {
        cuadros = new ArrayList<>();
    }

    @Id
    @GeneratedValue    
    @Column(name = "ID", nullable = false)
    public int getRut() {
        return rut;
    }
    public void setRut(int rut) {
        this.rut = rut;
    }
    
    @Column(name = "Denominacion")
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }

    @Column(name = "Domicilio")
    public String getDomicilio() {
        return domicilio;
    }
    public void setDomicilio(String domicilio) {
        this.domicilio = domicilio;
    }

    @OneToMany(mappedBy = "campoComercial")
    public List<Cuadro> getCuadros() {
        return cuadros;
    }
    public void setCuadros(List<Cuadro> cuadros) {
        this.cuadros = cuadros;
    }
        
    public double totalSuperficie(){
        double superficieTotal = 0;
        for (Cuadro cuadro : cuadros) {
            superficieTotal += cuadro.getSuperficie();
        }
        return superficieTotal;
    }
    
    public int totalPlantasMadres(){
        int totalPlantasMadre = 0;
        for (Cuadro cuadro : cuadros) {
            totalPlantasMadre += cuadro.totalPlantasMadres();
        }
        return totalPlantasMadre;
    }
    
    public int totalPlantasMadresXVariedad(String codigo){
        int cantPlantasMadresXVariedad = 0;
        for (Cuadro cuadro : cuadros) {
            for (PlantaMadre planta : cuadro.getPlantasMadre()) {
                if(planta.getVariedad().getCodigo() == codigo){
                    cantPlantasMadresXVariedad++;
                }
            }
        }
        return cantPlantasMadresXVariedad;
    }
    
    public PlantaMadre obtenerPlantaMadre(int cuadro, int nroDeOrden){
        for (Cuadro cua : cuadros) {
            if(cua.getNroCuadro() == cuadro){
                for (PlantaMadre planta : cua.getPlantasMadre()) {
                    if(planta.getNroDeOrden() == nroDeOrden){
                        return planta;
                    }else{
                        System.out.println("El numero de orden ingresado no corresponde a ninguna planta madre!");
                    }
                }
            }else{
                System.out.println("El cuadro ingresado no existe!");
            }            
        }
        return null;
    }   
}
