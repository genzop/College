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
public class CargoLaboral {
    
    private String cargo;
    private CargoLaboral nivelSuperior;
    private ArrayList<CargoLaboral> nivelInferior;

    public CargoLaboral() {
    }

    public CargoLaboral(String cargo) {
        this.cargo = cargo;
        this.nivelInferior = new ArrayList();
    } 

    public CargoLaboral getNivelSuperior() {
        return nivelSuperior;
    }
    public void setNivelSuperior(CargoLaboral nivelSuperior) {
        this.nivelSuperior = nivelSuperior;
    }
    public ArrayList<CargoLaboral> getNivelInferior() {
        return nivelInferior;
    }
    public void setNivelInferior(ArrayList<CargoLaboral> nivelInferior) {
        this.nivelInferior = nivelInferior;
    }   
    public String getCargo() {
        return cargo;
    }
    public void setCargo(String cargo) {
        this.cargo = cargo;
    }
    
    public void agregarAlNivelInferior(CargoLaboral cargoNuevo){
        this.nivelInferior.add(cargoNuevo);
        cargoNuevo.setNivelSuperior(this);
    }

    public ArrayList<CargoLaboral> getArbolDeCargos(CargoLaboral raiz, ArrayList<CargoLaboral> acumulador){        
        acumulador.add(raiz);
        if (raiz.getCargo() != null && raiz.getNivelInferior() != null) {
            for (CargoLaboral c : raiz.getNivelInferior()) {
                getArbolDeCargos(c, acumulador);
            }            
        }
        return acumulador;                
    }
}