/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import org.hibernate.Session;
import org.hibernate.Transaction;
import persistencia.ConfigHibernate;

/**
 *
 * @author Enzo
 */
public class Gestor {
    
    private static ConfigHibernate configHibernate;
    private Session sesion;

    public Gestor() {
        configHibernate = new ConfigHibernate();
        sesion = ConfigHibernate.openSession();
    }
    
    public void guardar(Object o) throws Exception{
        
        boolean guardar = false;
        Transaction tx = null;
        try {
            if (!sesion.getTransaction().isActive()) {
                tx = sesion.beginTransaction();
                guardar = true;
            }            
            sesion.saveOrUpdate(o);            
            if (guardar) {
                tx.commit();
                System.out.println("Objeto persistido");
            }
            
        } catch (Exception e) {
            if (guardar) {
                tx.rollback();
            }
            throw new Exception(e.getMessage());
        }
    }   
}
