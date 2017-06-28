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
public class Cliente {
    
    private int nroCliente;
    private String nombre;
    private String tipoDocumento;
    private long nroDocumento;
    private List<ComprobanteVenta> refComprobanteVenta;
    private List<CuentaCredito> refCuentaCredito;

    public Cliente() {
    }

    public Cliente(int nroCliente, String nombre, String tipoDocumento, long nroDocumento) {
        this.nroCliente = nroCliente;
        this.nombre = nombre;
        this.tipoDocumento = tipoDocumento;
        this.nroDocumento = nroDocumento;
        this.refComprobanteVenta = new ArrayList();
        this.refCuentaCredito = new ArrayList();
    }

    public List<ComprobanteVenta> getRefComprobanteVenta() {
        return refComprobanteVenta;
    }
    public void setRefComprobanteVenta(List<ComprobanteVenta> refComprobanteVenta) {
        this.refComprobanteVenta = refComprobanteVenta;
    }
    public List<CuentaCredito> getRefCuentaCredito() {
        return refCuentaCredito;
    }
    public void setRefCuentaCredito(List<CuentaCredito> refCuentaCredito) {
        this.refCuentaCredito = refCuentaCredito;
    }        
    public long getNroDocumento() {
        return nroDocumento;
    }
    public void setNroDocumento(long nroDocumento) {
        this.nroDocumento = nroDocumento;
    }
    public String getTipoDocumento() {
        return tipoDocumento;
    }
    public void setTipoDocumento(String tipoDocumento) {
        this.tipoDocumento = tipoDocumento;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public int getNroCliente() {
        return nroCliente;
    }
    public void setNroCliente(int nroCliente) {
        this.nroCliente = nroCliente;
    }
    
    public void agregarComprobante(ComprobanteVenta comprobanteNuevo){
        this.refComprobanteVenta.add(comprobanteNuevo);
        comprobanteNuevo.setRefCliente(this);
    }

    
}
