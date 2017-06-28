/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg1.ejercicio.pkg4;

import java.util.ArrayList;

/**
 *
 * @author Enzo
 */
public class Clase1Ejercicio4 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        CargoLaboral cargo1 = new CargoLaboral("Presidente");
        CargoLaboral cargo2 = new CargoLaboral("Vicepresidente");
        CargoLaboral cargo3 = new CargoLaboral("Gerente de Economia");
        CargoLaboral cargo4 = new CargoLaboral("Gerente de Recursos Humanos");
        CargoLaboral cargo5 = new CargoLaboral("Gerente de Legal");
        
       cargo1.agregarAlNivelInferior(cargo2);
       cargo2.agregarAlNivelInferior(cargo3);
       cargo2.agregarAlNivelInferior(cargo4);
       cargo2.agregarAlNivelInferior(cargo5);
       
       ArrayList<CargoLaboral> contenedorFinal = new ArrayList();
       
       contenedorFinal = cargo1.getArbolDeCargos(cargo1, contenedorFinal);
        for (CargoLaboral c : contenedorFinal) {
            System.out.println(c.getCargo());
        }
       
    }
    
}
