/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.d;

import java.util.Date;

/**
 *
 * @author Enzo
 */
public class TPNº1D {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        Date fecha1 = new Date(2016, 7, 16);
        
        Cliente cliente1 = new Cliente(1265, "Garcia Pedro", "DNI", 28654159);
        ComprobanteVenta comprobante1 = new ComprobanteVenta("Factura", fecha1, 6235478);
        Articulo art1 = new Articulo(65489, "Lavandina", 5, "Limpieza");
        Articulo art2 = new Articulo(58596, "Arroz", 8.5, "Alimentos");
        Articulo art3 = new Articulo(23665, "Leche", 25, "Lacteos");
        DetalleCompVenta detalle1 = new DetalleCompVenta(1, 2, art1);
        DetalleCompVenta detalle2 = new DetalleCompVenta(2, 3, art2);
        DetalleCompVenta detalle3 = new DetalleCompVenta(3, 4, art3);
        
        comprobante1.agregarDetalle(detalle1);
        comprobante1.agregarDetalle(detalle2);
        comprobante1.agregarDetalle(detalle3);
        
        comprobante1.calcularTotal();
        
        System.out.println("Cliente: " + cliente1.getNombre() + "\tNº: " + cliente1.getNroCliente() + "\t" + cliente1.getTipoDocumento() + " " + cliente1.getNroDocumento());
        System.out.println("Comprobante de Venta");
        System.out.println("Tipo: " + comprobante1.getTipo());
        System.out.println("Numero: " +comprobante1.getNumero());
        System.out.println("Total: $" + comprobante1.getTotal());
        System.out.println("Detalle - Articulos\tCodigo\tRubro\t\tCantidad\tPrecio\tSubtotal");
        System.out.println(art1.getNombre() + "\t\t" + art1.getCodigo() + "\t" + art1.getRubro() + "\t" + detalle1.getCantidad() + "\t\t" + art1.getPrecio() + "\t" + detalle1.calcularSubTotal());
        System.out.println(art2.getNombre() + "\t\t\t" + art2.getCodigo() + "\t" + art2.getRubro() + "\t" + detalle2.getCantidad() + "\t\t" + art2.getPrecio() + "\t" + detalle2.calcularSubTotal());
        System.out.println(art3.getNombre() + "\t\t\t" + art3.getCodigo() + "\t" + art3.getRubro() + "\t\t" + detalle3.getCantidad() + "\t\t" + art3.getPrecio() + "\t" + detalle3.calcularSubTotal());
        System.out.println("\t\t\t\t\t\t\t\t TOTAL $" + comprobante1.getTotal());
    }
    
}
