/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tp.nº1.d;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Enzo
 */
public class CuentaCredito {
    
    private int numero;
    private String denominacion;
    private double saldo;
    private List<Cliente> refCliente;

    public CuentaCredito() {
    }

    public CuentaCredito(int numero, String denominacion, double saldo) {
        this.numero = numero;
        this.denominacion = denominacion;
        this.saldo = saldo;
        this.refCliente = new ArrayList();
    }    

    public List<Cliente> getRefCliente() {
        return refCliente;
    }
    public void setRefCliente(List<Cliente> refCliente) {
        this.refCliente = refCliente;
    }   
    public double getSaldo() {
        return saldo;
    }
    public void setSaldo(double saldo) {
        this.saldo = saldo;
    }
    public String getDenominacion() {
        return denominacion;
    }
    public void setDenominacion(String denominacion) {
        this.denominacion = denominacion;
    }
    public int getNumero() {
        return numero;
    }
    public void setNumero(int numero) {
        this.numero = numero;
    }

}
