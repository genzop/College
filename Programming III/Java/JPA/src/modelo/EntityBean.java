/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

/**
 *
 * @author Enzo
 */
import java.io.Serializable;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.MappedSuperclass;

@MappedSuperclass// clase padre de las entidades
@Inheritance(strategy = InheritanceType.TABLE_PER_CLASS)// joined: crea 2 tablas unidas por id
                                                // singletable: 1 tabla con todos los atributos de las demas
                                                // txclass: copia los atributos del padre=redundancia
public abstract class EntityBean implements Serializable {
    
}
