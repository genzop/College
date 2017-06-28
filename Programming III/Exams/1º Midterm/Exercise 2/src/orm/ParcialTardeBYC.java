/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package orm;

import controlador.Gestor;
import modelo.CampoComercial;
import modelo.Cuadro;
import modelo.PlantaMadre;
import modelo.Variedad;

/**
 *
 * @author Enzo
 */
public class ParcialTardeBYC {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Gestor gestor = new Gestor();
        CampoComercial campo = new CampoComercial();
        campo.setDenominacion("Alimentos");
        campo.setDomicilio("San Martin 1265");
        
        Cuadro cuadro = new Cuadro();
        cuadro.setCantidadHileras(10);
        cuadro.setCantidadPlantasXHilera(10);
        cuadro.setSuperficie(105000);
        
        PlantaMadre planta = new PlantaMadre();
        planta.setHilera(1000);
        planta.setNroDeOrden(20);
        
        Variedad variedad = new Variedad();
        variedad.setCodigo("Kappa");
        variedad.setDenominacion("Cosas");
        variedad.setEspecie("Rara");
        
        campo.getCuadros().add(cuadro);
        cuadro.setCampoComercial(campo);
        
        cuadro.getPlantasMadre().add(planta);
        planta.setCuadro(cuadro);
        
        planta.setVariedad(variedad);
        variedad.getPlantasMadre().add(planta);
        try {
            gestor.guardar(planta);            
        } catch (Exception e) {
            e.printStackTrace();
        }
        
    }
    
}
