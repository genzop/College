/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package conexionjdbc;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author Enzo
 */
public class GestorTabla {
    
    public static void configurarColumnas(ResultSet rs, DefaultTableModel modelo){
        try {
            ResultSetMetaData metaDatos = rs.getMetaData();
            int cantColumnas = metaDatos.getColumnCount();
            Object[] nombreColumnas = new Object[cantColumnas];
            for (int i = 0; i < nombreColumnas.length; i++) {
                nombreColumnas[i] = metaDatos.getColumnLabel(i + 1);                
            }
            modelo.setColumnIdentifiers(nombreColumnas);            
        } catch (Exception e) {
            e.printStackTrace();
        }       
    }
    
    public static void vaciarFilas(DefaultTableModel modelo){
        try {
            while (modelo.getRowCount() > 0) {                
                modelo.removeRow(0);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    public static void agregarFilas(ResultSet rs, DefaultTableModel modelo){
        try {
            while (rs.next()) {                
                int cantColumnas = modelo.getColumnCount();
                Object[] datos = new Object[cantColumnas];
                for (int i = 0; i < datos.length; i++) {
                    datos[i] = rs.getObject(i + 1);                    
                }
                modelo.addRow(datos);
            }
            rs.close();
        } catch (Exception e) {
        }
    }   
}
