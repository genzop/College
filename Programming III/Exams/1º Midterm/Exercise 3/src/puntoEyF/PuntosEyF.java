/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package puntoEyF;

/**
 *
 * @author Enzo
 */
public class PuntosEyF {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Gestor gestor = new Gestor();
        gestor.establecerConexion();
        gestor.insertarCampoComercial();
        gestor.guardarArchivo("C:\\Users\\Enzo\\Desktop\\campo_comercial.txt");
    }
    
}
