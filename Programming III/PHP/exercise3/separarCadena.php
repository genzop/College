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
        $cadena = $_REQUEST['cadena'];             
        $matriz = str_split($cadena,1);      
        
        foreach ($matriz as $value) {
            echo "<b>$value </b>";
        }       
        ?>
    </body>
</html>
