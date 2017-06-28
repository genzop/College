/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package trabajo.practico.nº5;

import java.io.*;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.Statement;
import java.util.ArrayList;

/**
 *
 * @author Enzo
 */
public class Gestor {
    
    private Conexion con;
    private Connection conexion;

    public Gestor() {
        con = new Conexion();
        conexion = con.establecerConexion();
    }
    
    public ArrayList<String> traerTabla(){
        ArrayList<String> paises = new ArrayList();        
        try {
            Statement s = conexion.createStatement();
            ResultSet rs = s.executeQuery("SELECT * FROM countries");
            ResultSetMetaData metaDatos = rs.getMetaData();                        
                                            
            while (rs.next()) {  
                String pais = "";
                int cantColumnas = metaDatos.getColumnCount();
                for (int i = 1; i <= cantColumnas; i++) {                    
                    pais += rs.getString(i);      
                    if(i < cantColumnas){
                        pais += ";";
                    }                    
                }      
                paises.add(pais);
            }         
        } catch (Exception e) {
            e.printStackTrace();
        }    
        return paises;
    }
    
    public void guardarArchivo(ArrayList<String> lista, String ubicacion){
        FileWriter archivo = null;
        PrintWriter pw = null;
        
        try {
            archivo = new FileWriter(ubicacion);
            pw = new PrintWriter(archivo);
            for (String pais : lista) {
                pw.println(pais);
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
    
    public ArrayList<String> leerArchivo(String ubicacion){
        ArrayList<String> lista = new ArrayList();
        File archivo = null;
        FileReader fr = null;
        BufferedReader br = null;
        
        try {
            archivo = new File(ubicacion);
            fr = new FileReader(archivo);
            br = new BufferedReader(fr);
            
            String linea = "";
            while ((linea=br.readLine()) != null) {                
                lista.add(linea);
            }            
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                if (fr != null) {
                    fr.close();
                }
            } catch (Exception e) {
                e.printStackTrace();
            }           
        }
        return lista;
    }  
    
    public void guardarTabla(ArrayList<String> paises){
        try {
            for (String pais : paises) {
                String[] campos = pais.split(";");
                PreparedStatement ps = conexion.prepareStatement("INSERT INTO countries_copia VALUES (default, ?, ?) ");
                ps.setString(1, campos[1]);
                ps.setString(2, campos[2]);
                ps.executeUpdate();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
