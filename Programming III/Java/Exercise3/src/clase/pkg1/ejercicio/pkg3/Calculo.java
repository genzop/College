/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg1.ejercicio.pkg3;

/**
 *
 * @author Enzo
 */
public class Calculo {
    
    public double raizCuadrada(double numero){
        double resultado = Math.sqrt(numero);
        if (resultado > 1.2) {
            resultado = raizCuadrada(resultado);
        }
        return resultado;
    }
}
