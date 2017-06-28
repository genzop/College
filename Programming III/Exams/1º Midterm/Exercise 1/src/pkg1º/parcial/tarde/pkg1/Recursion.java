/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg1º.parcial.tarde.pkg1;

/**
 *
 * @author Enzo
 */
public class Recursion {
    
    public double raizCuadrada(double numero){
        numero = Math.sqrt(numero);
        System.out.println(numero);
        if(numero >= 1.10){
            numero = raizCuadrada(numero);
        }
        return numero;
    }
}
