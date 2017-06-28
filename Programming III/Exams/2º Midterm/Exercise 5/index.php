<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Ejercicio 6</title>
    </head>
    <body>
        <form action="resultado.php" method="get">
            <table style="border-collapse: collapse; margin-left: auto; margin-right: auto; width: 50%; font-family: arial; font-size: 12px">
                <tr>
                    <td style="border: 1px black solid; text-align: center" colspan="2">
                        <img src="Olimpiadas.jpg"/>
                    </td>                                    
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Deporte
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <input type="text" id="deporte" name="deporte" >
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Clasificación
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <select id="clasificacion" name="clasificacion">
                            <option value="Medicion por tiempo">Medicion por tiempo</option>
                            <option value="Deporte de Anotacion">Deporte de Anotacion</option>
                            <option value="Deporte de Calificacion">Deporte de Califcacion</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Tipo
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <table>
                            <tr>
                                <td><input type="radio" id="tipoColectivo" name="tipo" value="Colectivo"></td>
                                <td>Colectivo</td>
                            </tr>
                            <tr>
                                <td><input type="radio" id="tipoIndividual" name="tipo" value="Individual"></td>
                                <td>Individual</td>
                            </tr>                            
                        </table>                                              
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Cantidad de jugadores
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <input type="text" id="cantJugadores" name="cantJugadores">
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Categoria
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <table>
                            <tr>
                                <td><input type="checkbox" id="categoriaInfatil" name="categoriaInfantil" value="Infatil"></td>
                                <td>Infantil</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox" id="categoriaJuvenil" name="categoriaJuvenil" value="Juvenil"></td>
                                <td>Juvenil</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox" id="categoriaMayores" name="categoriaMayores" value="Mayores"></td>
                                <td>Mayores</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%">
                        Descripción
                    </td>
                    <td style="border: 1px black solid; width: 50%">
                        <textarea id="descripcion" name="descripcion" rows="8" cols="34"></textarea>   
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px black solid; font-weight: bold; width: 50%"></td>
                    <td style="border: 1px black solid; width: 50%">     
                        <input type="submit" value="Agregar">
                    </td>
                </tr>                
            </table>
        </form>
    </body>
</html>
