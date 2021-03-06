/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package conexionjdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import javax.swing.JOptionPane;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author Enzo
 */
public class PantallaConsulta extends javax.swing.JFrame {

    private Connection conexion = null;
    private String host;
    private String puerto;
    private String baseDeDatos;
    private String usuario;
    private String contrasenia;
    private String consultaSQL;
    private GestorTabla gestorTabla;
    private DefaultTableModel modelo;
    
    
    /**
     * Creates new form PantallaConsulta
     */
    
    public PantallaConsulta() {
        initComponents();
        setLocationRelativeTo(this);
        gestorTabla = new GestorTabla();
        modelo = new DefaultTableModel();
    }
    
    public void tomarDatos(){
        try {
            host = txtHost.getText();
            puerto = txtPuerto.getText();
            baseDeDatos = txtBaseDatos.getText();
            usuario = txtUsuario.getText();
            contrasenia = txtContrasenia.getText();
            consultaSQL = txtConsultaSQL.getText();
        } catch (Exception e) {
            e.printStackTrace();
        }        
    }
    
    public void establecerConexion(){
        try {
            Class.forName("com.mysql.jdbc.Driver");
            String urlConexion = "jdbc:mysql://" + host + ":" + puerto + "/" + baseDeDatos;
            conexion = DriverManager.getConnection(urlConexion, usuario, contrasenia);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    public void mostrar(){
        try {
            Statement s = conexion.createStatement();
            ResultSet rs = s.executeQuery(consultaSQL);
            GestorTabla.configurarColumnas(rs, modelo);         
            GestorTabla.vaciarFilas(modelo);
            GestorTabla.agregarFilas(rs, modelo);            
            tablaPersonas.setModel(modelo);
            tablaPersonas.getColumnModel().removeColumn(tablaPersonas.getColumnModel().getColumn(0));            
        } catch (Exception e) {
            e.printStackTrace();
        }        
    }
    
    public void actualizarTabla(){
        try {
            Statement s = conexion.createStatement();
            s.executeUpdate(consultaSQL);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        lblHost = new javax.swing.JLabel();
        lblPuerto = new javax.swing.JLabel();
        lblBaseDatos = new javax.swing.JLabel();
        txtBaseDatos = new javax.swing.JTextField();
        txtPuerto = new javax.swing.JTextField();
        txtHost = new javax.swing.JTextField();
        lblUsuario = new javax.swing.JLabel();
        lblContrasenia = new javax.swing.JLabel();
        txtContrasenia = new javax.swing.JTextField();
        txtUsuario = new javax.swing.JTextField();
        lblConsultaSQL = new javax.swing.JLabel();
        txtConsultaSQL = new javax.swing.JTextField();
        btnEjecutar = new javax.swing.JButton();
        lblResultado = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablaPersonas = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        lblHost.setText("Host");

        lblPuerto.setText("Puerto");

        lblBaseDatos.setText("Base de Datos");

        txtHost.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtHostActionPerformed(evt);
            }
        });

        lblUsuario.setText("Usuario");

        lblContrasenia.setText("Contraseña");

        lblConsultaSQL.setText("Consulta SQL");

        txtConsultaSQL.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtConsultaSQLActionPerformed(evt);
            }
        });

        btnEjecutar.setText("Ejecutar SQL");
        btnEjecutar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnEjecutarActionPerformed(evt);
            }
        });

        lblResultado.setText("Resultado");

        tablaPersonas.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        jScrollPane1.setViewportView(tablaPersonas);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(lblResultado)
                    .addComponent(lblConsultaSQL)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(lblBaseDatos)
                            .addComponent(lblPuerto)
                            .addComponent(lblHost))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(txtBaseDatos, javax.swing.GroupLayout.DEFAULT_SIZE, 100, Short.MAX_VALUE)
                            .addComponent(txtPuerto)
                            .addComponent(txtHost))
                        .addGap(65, 65, 65)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(lblContrasenia)
                            .addComponent(lblUsuario))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(txtContrasenia)
                            .addComponent(txtUsuario, javax.swing.GroupLayout.DEFAULT_SIZE, 100, Short.MAX_VALUE)))
                    .addComponent(txtConsultaSQL)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 410, Short.MAX_VALUE))
                .addContainerGap(20, Short.MAX_VALUE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(btnEjecutar)
                .addGap(176, 176, 176))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(16, 16, 16)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lblHost)
                    .addComponent(txtHost, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lblUsuario)
                    .addComponent(txtUsuario, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lblPuerto)
                    .addComponent(txtPuerto, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lblContrasenia)
                    .addComponent(txtContrasenia, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lblBaseDatos)
                    .addComponent(txtBaseDatos, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addComponent(lblConsultaSQL)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(txtConsultaSQL, javax.swing.GroupLayout.PREFERRED_SIZE, 58, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(btnEjecutar)
                .addGap(25, 25, 25)
                .addComponent(lblResultado)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 148, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(21, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void txtConsultaSQLActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtConsultaSQLActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtConsultaSQLActionPerformed

    private void txtHostActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtHostActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtHostActionPerformed

    private void btnEjecutarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnEjecutarActionPerformed
        // TODO add your handling code here:
        tomarDatos();
        establecerConexion();
        if (consultaSQL.startsWith("S") || consultaSQL.startsWith("s")) {
            mostrar();
        } else if (consultaSQL.startsWith("I") || consultaSQL.startsWith("i")){
            actualizarTabla();
            JOptionPane.showMessageDialog(rootPane, "Se agrego el registro exitosamente");
        } else if (consultaSQL.startsWith("D") || consultaSQL.startsWith("d")){
            actualizarTabla();
            JOptionPane.showMessageDialog(rootPane, "Se borro el registro exitosamente");
        } else if (consultaSQL.startsWith("U") || consultaSQL.startsWith("u")){
            actualizarTabla();
            JOptionPane.showMessageDialog(rootPane, "Se actualizo el registro exitosamente");
        }
        txtConsultaSQL.setText("");
    }//GEN-LAST:event_btnEjecutarActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(PantallaConsulta.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(PantallaConsulta.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(PantallaConsulta.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(PantallaConsulta.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new PantallaConsulta().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnEjecutar;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel lblBaseDatos;
    private javax.swing.JLabel lblConsultaSQL;
    private javax.swing.JLabel lblContrasenia;
    private javax.swing.JLabel lblHost;
    private javax.swing.JLabel lblPuerto;
    private javax.swing.JLabel lblResultado;
    private javax.swing.JLabel lblUsuario;
    private javax.swing.JTable tablaPersonas;
    private javax.swing.JTextField txtBaseDatos;
    private javax.swing.JTextField txtConsultaSQL;
    private javax.swing.JTextField txtContrasenia;
    private javax.swing.JTextField txtHost;
    private javax.swing.JTextField txtPuerto;
    private javax.swing.JTextField txtUsuario;
    // End of variables declaration//GEN-END:variables
}
