<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body style="font-family: arial">
        <?php
            //Se toman todos los datos
            $deporte = $_REQUEST['deporte'];
            $clasificacion = $_REQUEST['clasificacion'];
            $tipo = $_REQUEST['tipo'];
            $cantJugadores = $_REQUEST['cantJugadores'];
            $categoria = ''; 
            if (isset($_REQUEST['categoriaInfantil'])) {
                if($categoria == ''){
                    $categoria = $_REQUEST['categoriaInfantil'];
                }else{
                    $categoria .= ', ' . $_REQUEST['categoriaInfantil'];
                }                
            }            
            if (isset($_REQUEST['categoriaJuvenil'])) {
                if($categoria == ''){
                    $categoria = $_REQUEST['categoriaJuvenil'];
                }else{
                    $categoria .= ', ' . $_REQUEST['categoriaJuvenil'];
                }                
            }            
            if (isset($_REQUEST['categoriaMayores'])) {
                if($categoria == ''){
                    $categoria = $_REQUEST['categoriaMayores'];
                }else{
                    $categoria .= ', ' . $_REQUEST['categoriaMayores'];
                }                
            }
            $descripcion = $_REQUEST['descripcion'];            
        ?>
        <?php
        
            $servername = "localhost";
            $username = "root";
            $password = "";

            // Crear conexion
            $conn = new mysqli($servername, $username, $password, 'segundoparcialtarde', 3306);

            // Comprobar conexion
            if ($conn->connect_error) {
                die("Fallo la conexion: " . $conn->connect_error);
            } 
            echo "Conexion exitosa";
	
            // Insertar registro
            $sql = "INSERT INTO deporte (Deporte, Clasificacion, Tipo, Cantidad_de_Jugadores, Categoria, Descripcion) "
                 . "VALUES ('" . $deporte . "', '" . $clasificacion . "', '" . $tipo . "', '" . $cantJugadores . "', '" . $categoria . "', '" . $descripcion . "')";

            if ($conn->query($sql) === TRUE) {
                echo "<br>Se agrego un nuevo deporte!";
                $last_id = $conn->insert_id;                
            } else {
                echo "Error: " . $sql . "<br>" . $conn->error;
            }
            
            // Mostrar todos los registros
            $sql = "SELECT * FROM deporte";
            $result = $conn->query($sql);

            if ($result->num_rows > 0) {
                // Mostrar los datos de cada fila
                echo "<br><br>";
                echo "<table style='border-collapse: collapse'>";
                echo "<tr>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>ID</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Deporte</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Clasificacion</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Tipo</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Cantidad de Jugadores</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Categoria</td>";
                echo "<td style='border: 1px black solid; text-align: center; font-weight: bold'>Descripcion</td>";
                echo "</tr>";
                
                while($row = $result->fetch_assoc()) {
                    echo "<tr>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["ID"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Deporte"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Clasificacion"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Tipo"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Cantidad_de_Jugadores"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Categoria"]. "</td>";
                    echo "<td style='border: 1px black solid; text-align: center; padding: 3px'>" . $row["Descripcion"]. "</td>";                    
                    echo "</tr>";
                }
                echo "</table>";
            } else {
                echo "No se encontro ningun resultado";
            }
            $conn->close();        
        ?>        
    </body>
</html>
