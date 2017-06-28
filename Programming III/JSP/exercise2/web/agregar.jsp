<%-- 
    Document   : agregar
    Created on : 27/10/2016, 09:56:18
    Author     : Enzo
--%>

<%@page import="controlador.Gestor"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Ejercicio 2</title>
    </head>
    <body style="font-family: arial">
        <%
        int dni = Integer.parseInt(request.getParameter("dni"));
        String nombre = request.getParameter("nombre");
        String domicilio = request.getParameter("domicilio");
        
        Gestor gestor = new Gestor();
        gestor.agregarPersona(dni, nombre, domicilio);
        out.print("<b> El siguiente registro se agrego con exito:</b><br><br>");
        out.print("Dni: " + dni + "<br>");
        out.print("Nombre: " + nombre + "<br>");
        out.print("Domicilio: " + domicilio + "<br>");        
        %>
    </body>
</html>
