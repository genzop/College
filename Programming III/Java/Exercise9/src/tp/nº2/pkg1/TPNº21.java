/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº2.pkg1;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author Enzo
 */
public class TPNº21 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        ArrayList<Articulo> articulos = new ArrayList();
        Articulo art1 = new Articulo(111111, 10);
        Articulo art2 = new Articulo(222222, 20);
        articulos.add(art1);
        articulos.add(art2);
        Date fecha1 = new Date(2016, 7, 19);
        Factura factura1 = new Factura(fecha1, 123456, 0, 2, articulos);
        Cliente cliente1 = new Cliente("Consumidor Final", "24-389489486-9", "Juan Jufre", 2218);
        cliente1.agregarFactura(factura1);        
                                
    }
    
}
