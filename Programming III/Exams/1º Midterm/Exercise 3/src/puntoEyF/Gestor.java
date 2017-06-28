/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package puntoEyF;

import java.io.FileWriter;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 *
 * @author Enzo
 */
public class Gestor {
    
    private Connection conexion = null;
    
    public void establecerConexion(){
        if(conexion == null){
            try {
                Class.forName("com.mysql.jdbc.Driver");           
                String url = "jdbc:mysql://localhost:3306/primerparcialtarde";
                conexion = DriverManager.getConnection(url, "root", "");
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    
    public void insertarCampoComercial(){
        if(conexion != null){
            try {
                int id = Integer.parseInt(JOptionPane.showInputDialog("Ingresar el ID:"));
                String domicilio = JOptionPane.showInputDialog("Ingresar el domicilio:");
                String denominacion = JOptionPane.showInputDialog("Ingresar la denominacion:");
                
                PreparedStatement ps = conexion.prepareStatement("INSERT INTO campo_comercial (ID, Domicilio, Denominacion) VALUES (?, ?, ?)");
                ps.setInt(1, id);
                ps.setString(2, domicilio);
                ps.setString(3, denominacion);
                ps.executeUpdate();                
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    
    public void guardarArchivo(String ubicacion){
        if(conexion != null){
            ArrayList<String> tabla = new ArrayList<>();
            FileWriter archivo = null;
            PrintWriter pw = null;
            
            try {
                Statement s = conexion.createStatement();
                ResultSet rs = s.executeQuery("SELECT * FROM campo_comercial");
                int cantColumnas = rs.getMetaData().getColumnCount();
                
                while(rs.next()){
                    String datosFila = "";
                    for (int i = 1; i <= cantColumnas; i++) {
                        if(i < cantColumnas){
                            datosFila += rs.getString(i) + "\t";
                        }else{
                            datosFila += rs.getString(i);
                        }
                    }
                    tabla.add(datosFila);
                }
                
                archivo = new FileWriter(ubicacion);
                pw = new PrintWriter(archivo);
                
                for (String fila : tabla) {
                    pw.println(fila);
                }
            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                try {
                    if (archivo != null) {
                        archivo.close();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }                
            }
        }
    }    
}

