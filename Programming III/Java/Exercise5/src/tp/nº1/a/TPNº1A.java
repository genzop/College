/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.a;

import java.util.Scanner;
import javax.swing.JOptionPane;

/**
 *
 * @author Enzo
 */
public class TPNº1A {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       
        int numeroAleatorio = new Double(Math.random() * 100).intValue();
        int numeroIngresado = 0;        
        int contador = 0;
        System.out.println("Número aleatorio generado: " + numeroAleatorio);
        
        do {
            System.out.println ("Ingrese un número entre 0 y 100:");
            String auxNumeroIngresado = "";            
            auxNumeroIngresado = JOptionPane.showInputDialog("Ingrese un numero: ");
            numeroIngresado = Integer.parseInt(auxNumeroIngresado);
            System.out.println("Numero Ingresado: " + numeroIngresado);
            contador++;
            if (numeroIngresado > numeroAleatorio) {
                System.out.println("Respuesta: Es muy alto");
            } else if (numeroIngresado < numeroAleatorio){
                System.out.println("Respuesta: Es muy bajo");
            } else {
                System.out.println("Correcto, numero encontrado, cantidad de intentos " + contador);
            }
        } while (numeroIngresado != numeroAleatorio);            
    }    
}