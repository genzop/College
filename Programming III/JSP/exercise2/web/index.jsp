<%-- 
    Document   : index
    Created on : 27/10/2016, 09:47:11
    Author     : Enzo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Ejercicio 2</title>
    </head>
    <body style="font-family: arial">
        <form action="agregar.jsp" method="get">
            <table>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <h2>Agregar una persona</h2>
                    </td>                    
                </tr>
                <tr>
                    <td style="text-align: right">Dni:</td>
                    <td><input type="text" name="dni"></td>
                </tr>
                <tr>
                    <td style="text-align: right">Nombre:</td>
                    <td><input type="text" name="nombre"></td>
                </tr>
                <tr>
                    <td style="text-align: right">Domicilio:</td>
                    <td><input type="text" name="domicilio"></td>
                </tr>
                <tr>                    
                    <td colspan="2" style="text-align: center; padding-top: 10px"><input type="submit" value="Agregar"></td>
                </tr>
            </table>
        </form>
    </body>
</html>
