/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package conexion;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 *
 * @author Enzo
 */
public class BaseDeDatos {
    
    private Connection conexion = null;
    private String host = "localhost";
    private String puerto = "3306";
    private String baseDatos = "jsp";
    private String usuario = "root";
    private String password = "";
    
    public Connection establecerConexion(){
        if(conexion != null){
            return conexion;
        }
        try {
            Class.forName("com.mysql.jdbc.Driver");
            String url = "jdbc:mysql://" + host + ":" + puerto + "/" + baseDatos;
                    conexion = DriverManager.getConnection(url, usuario, password);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return conexion;
    }
    
    public void cerrarConexion(){
        try {
            conexion.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
