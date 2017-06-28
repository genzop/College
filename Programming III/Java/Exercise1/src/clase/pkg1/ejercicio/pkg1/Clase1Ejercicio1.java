/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg1.ejercicio.pkg1;

/**
 *
 * @author Enzo
 */
public class Clase1Ejercicio1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Ruta ruta = new Ruta("Ruta Principal");
        TramoRuta tr1 = new TramoRuta(25, 1);
        TramoRuta tr2 = new TramoRuta(35, 2);
        TramoRuta tr3 = new TramoRuta(15, 3);
        TramoRuta tr4 = new TramoRuta(45, 4);
        TramoRuta tr5 = new TramoRuta(5, 5);
        
        ruta.agregarTramo(tr1);
        ruta.agregarTramo(tr2);
        ruta.agregarTramo(tr3);
        ruta.agregarTramo(tr4);
        ruta.agregarTramo(tr5);
        
        System.out.println(ruta.calcularTotalKmRuta());
        System.out.println(tr1.calcularTotalKmXRango(3, 5));
        
    }
    
}
