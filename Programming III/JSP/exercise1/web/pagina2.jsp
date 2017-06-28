<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Pagina 2</title>
    </head>
    <body>
        <%
        int filas = Integer.parseInt(request.getParameter("filas"));
        int columnas = Integer.parseInt(request.getParameter("columnas"));
        out.print("<table style='border-collapse: collapse; font-family: arial'>");
            for (int i = 0; i < filas; i++) {      
                out.print("<tr>");
                    for (int j = 0; j < columnas; j++) {
                        out.print("<td style='border: 2px black solid; width: 100px'>");   
                            out.print((i+1 + "." + (j+1)));
                        out.print("</td>");
                    }    
                out.print("</tr>");                       
            }         
        out.print("</table>");    
        %>
    </body>
</html>
