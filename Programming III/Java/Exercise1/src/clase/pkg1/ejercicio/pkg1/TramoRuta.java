/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clase.pkg1.ejercicio.pkg1;

/**
 *
 * @author Enzo
 */
public class TramoRuta {
    
    private int cantKm;        
    private int nroTramo;
    private Ruta rutaPrincipal;

    public TramoRuta() {
    }
    
    public TramoRuta(int cantKm, int nroTramo) {
        this.cantKm = cantKm;
        this.nroTramo = nroTramo;
    }

    public Ruta getRutaPrincipal() {
        return rutaPrincipal;
    }
    public void setRutaPrincipal(Ruta rutaPrincipal) {
        this.rutaPrincipal = rutaPrincipal;
    }    
    public int getNroTramo() {
        return nroTramo;
    }
    public void setNroTramo(int nroTramo) {
        this.nroTramo = nroTramo;
    }
    public int getCantKm() {
        return cantKm;
    }
    public void setCantKm(int cantKm) {
        this.cantKm = cantKm;
    }
    
    public int calcularTotalKmXRango(int tramoInicial, int tramoFinal){
        int totalKmXRango = 0;
        if (tramoInicial >= 0 && tramoFinal >= 0) {
            for (TramoRuta tr : rutaPrincipal.getTramos()) {
                if (tr.getNroTramo() >= tramoInicial && tr.getNroTramo() <= tramoFinal) {
                    totalKmXRango += tr.getCantKm();
                }
            }
        }
        return totalKmXRango;
    }
}
