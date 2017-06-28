/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trabajo.practico.nº5;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 *
 * @author Enzo
 */
public class Conexion {
    
    private Connection conexion = null;
    private String host = "localhost";
    private String puerto = "3306";
    private String user = "root";
    private String password = "";
    private String baseDeDatos = "paises";

    public Conexion() {
    }
    
     
    public Connection establecerConexion(){
        if (conexion != null) {
            return conexion;
        } else {
            try {
                Class.forName("com.mysql.jdbc.Driver");
                String url = "jdbc:mysql://" + host + ":" + puerto + "/" + baseDeDatos;
                conexion = DriverManager.getConnection(url, user, password);
            } catch (Exception e) {
                e.printStackTrace();
            }
            return conexion;
        }
    }

    
    public void cerrarConexion(){
        try {
            if (conexion != null) {
                conexion.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    
}
