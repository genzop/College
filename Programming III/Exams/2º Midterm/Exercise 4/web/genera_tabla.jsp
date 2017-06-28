<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
            int filas = Integer.parseInt(request.getParameter("filas"));
            int columnas = Integer.parseInt(request.getParameter("columnas"));
            int posicion = 0;
            int direccion = 1;
            
            out.print("<table style='border-collapse: collapse; font-family: arial'>");            
                for (int i = 0; i < filas; i++) {                        
                    out.print("<tr>");
                    for (int j = 0; j < columnas; j++) {
                        out.print("<td style='border: 1px black solid; width: 150px; text-align: center'>");
                            if(posicion == j){
                                out.print("<b>1</b>");
                            }else{
                                out.print("0");
                            }
                        out.print("</td>");
                    }
                    out.print("</tr>");
                    
                    posicion += direccion;
                    
                    if(posicion == columnas - 1){
                        direccion = -1;
                    }
                    if(posicion == 0){
                        direccion = 1;
                    }                    
                }
            out.print("</table>");
        %>
    </body>
</html>
