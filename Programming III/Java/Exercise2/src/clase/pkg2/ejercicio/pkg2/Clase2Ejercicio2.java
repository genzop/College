/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg2.ejercicio.pkg2;

import java.util.Date;

/**
 *
 * @author Enzo
 */
public class Clase2Ejercicio2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Date fecha1 = new Date(2016, 7, 14);
        Date fecha2 = new Date(2015, 8, 10);
        Cliente cliente1 = new Cliente(1, "Enzo");
        Factura factura1 = new Factura(100, fecha2, false);
        Factura factura2 = new Factura(201, fecha1, false);
        Factura factura3 = new Factura(202, fecha1, true);
        DetalleFactura detalle1 = new DetalleFactura(10);
        DetalleFactura detalle2 = new DetalleFactura(5);
        DetalleFactura detalle3 = new DetalleFactura(20);
        Articulo art1 = new Articulo(5, "Arroz", "11111");
        Articulo art2 = new Articulo(90, "Nutella", "41254");
        Articulo art3 = new Articulo(30, "Pan", "00001");
        
        detalle1.agregarArticulo(art1);
        detalle2.agregarArticulo(art2);
        detalle3.agregarArticulo(art3);
        
        factura1.agregarDetalle(detalle1);
        factura1.agregarDetalle(detalle2);
        factura1.agregarDetalle(detalle3);
        
        factura2.agregarDetalle(detalle1);
        
        factura3.agregarDetalle(detalle3);
        
        cliente1.agregarFactura(factura1);
        cliente1.agregarFactura(factura2);
        cliente1.agregarFactura(factura3);
        
        System.out.println("Detalle Nº1: $" + detalle1.getSubTotal());
        System.out.println("Detalle Nº2: $" + detalle2.getSubTotal());
        System.out.println("Detalle Nº3: $" + detalle3.getSubTotal());
        
        System.out.println("Factura Nº1: $" + factura1.getTotalFactura());
        System.out.println("Factura Nº2: $" + factura2.getTotalFactura());
        System.out.println("Factura Nº3: $" + factura3.getTotalFactura());
        
        System.out.println("Total facturas activas: $" + cliente1.getTotalFacturasActivas());
        System.out.println("Total facturas del 2015: $" + cliente1.getTotalFacturasXAnio(2015));
        System.out.println("Total facturas del 2016: $" + cliente1.getTotalFacturasXAnio(2016));
        
        
        
               
        
        
    }
    
}
