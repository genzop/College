/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import conexion.BaseDeDatos;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Enzo
 */
public class Gestor {
 
    private BaseDeDatos bd;
    private Connection conexion;

    public Gestor() {
        bd = new BaseDeDatos();
        conexion = bd.establecerConexion();
    }
    
    public void agregarPersona(int dni, String nombre, String domicilio){
        try {
            PreparedStatement ps = conexion.prepareStatement("INSERT INTO persona (dni, nombre, domicilio) VALUES (?, ?, ?)");
            ps.setInt(1, dni);
            ps.setString(2, nombre);
            ps.setString(3, domicilio);
            ps.executeUpdate();
        } catch (SQLException ex) {
            Logger.getLogger(BaseDeDatos.class.getName()).log(Level.SEVERE, null, ex);
        }        
    }   
    
    public ResultSet mostrarPersonas(){
        ResultSet rs = null;
        try {
            Statement s = conexion.createStatement();
            rs = s.executeQuery("SELECT * FROM persona");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return rs;
    }
}
