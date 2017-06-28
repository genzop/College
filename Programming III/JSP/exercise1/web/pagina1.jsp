<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Pagina 1</title>
    </head>
    <body>
        <form action="pagina2.jsp" method="get">
            <table>
                <tr>
                    <td>Filas:</td>
                    <td><input type="text" name="filas"></td>
                </tr>
                <tr>
                    <td>Columnas:</td>
                    <td><input type="text" name="columnas"></td>
                </tr>
                <tr>
                    <td><input type="submit" value="Enviar"></td>                    
                </tr>
            </table>           
        </form>
    </body>
</html>
