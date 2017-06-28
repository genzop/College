<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <form action="genera_tabla.jsp" method="get">
            <table style="font-family: arial">
                <tr>
                    <td>Filas:</td>
                    <td>
                        <input type="text" id="filas" name="filas">
                    </td>
                </tr>
                <tr>
                    <td>Columnas:</td>
                    <td>
                        <input type="text" id="columnas" name="columnas">
                    </td>
                </tr>                
                <tr>
                    <td style="padding: 10px; text-align: right" colspan="2">
                        <input type="submit" value="Generar matriz">
                    </td>                
                </tr>
            </table>
        </form>
    </body>
</html>
