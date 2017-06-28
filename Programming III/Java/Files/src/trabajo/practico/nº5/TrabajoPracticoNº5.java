/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trabajo.practico.nº5;

import java.util.ArrayList;


/**
 *
 * @author Enzo
 */
public class TrabajoPracticoNº5 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
                    
        Gestor gestor = new Gestor(); 
        ArrayList<String> paises = gestor.traerTabla();
        gestor.guardarArchivo(paises, "C:\\Users\\Enzo\\Downloads\\prueba.txt");
        
        ArrayList<String> paisesCargados = gestor.leerArchivo("C:\\Users\\Enzo\\Downloads\\prueba.txt");
        gestor.guardarTabla(paises);
    }   
}
