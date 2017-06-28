<%-- 
    Document   : mostrar
    Created on : 27/10/2016, 11:20:03
    Author     : Enzo
--%>

<%@page import="controlador.Gestor"%>
<%@page import="java.sql.ResultSet"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <table style="border-collapse: collapse; font-family: arial">
            <tr>
                <td style="border: 1px black solid; width: 100px; text-align: center; font-weight: bold">Dni</td>
                <td style="border: 1px black solid; width: 200px; text-align: center; font-weight: bold">Nombre</td>
                <td style="border: 1px black solid; width: 300px; text-align: center; font-weight: bold">Domicilio</td>
            </tr>
            <%
                Gestor gestor = new Gestor();
                ResultSet rs = gestor.mostrarPersonas();
                while(rs.next()){
                    out.print("<tr>");
                        out.print("<td style='border: 1px black solid; text-align: center'>");
                            out.print(rs.getString("Dni"));
                        out.print("</td>");
                        out.print("<td style='border: 1px black solid'>");
                            out.print(rs.getString("Nombre"));
                        out.print("</td>");
                        out.print("<td style='border: 1px black solid'>");
                            out.print(rs.getString("Domicilio"));
                        out.print("</td>");
                    out.print("</tr>");
                }
            %>
        </table>
    </body>
</html>
