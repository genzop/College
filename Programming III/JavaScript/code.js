//Ejercicio 1
function ejercicio1() {
    var mensaje1 = "Hola Mundo!";
    var mensaje2 = "Soy el primer script";
    alert(mensaje1);           
    alert(mensaje2);
}

//Ejercicio 2
function ejercicio2(){
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    for (var i = 0; i < meses.length; i++) {
        alert(meses[i]);
    }
}

//Ejercicio 3
function ejercicio3(){
    var numero1 = 5; var numero2 = 8;
    if (!(numero1 > numero2)) {
        alert("numero1 no es mayor que numero2");
    }
    if (numero2 >= 0) {
        alert("numero2 es positivo");
    }  if (numero1 < 0 || numero1 !== 0) {
        alert("numero1 es negativo o distinto de cero");
    }  if (!(numero1 + 1 >= numero2)) {
        alert("Incrementar en 1 unidad el valor de numero1 no lo hace mayor o igual que numero2");  
    }
}

//Ejercicio 4
function ejercicio4(){
    var letras = ['T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E', 'T'];      
    var numeroDNI = prompt("Ingrese su número de DNI:");
    var letraDNI = prompt("Ingrese la letra de su DNI:");
    if(numeroDNI < 0 || numeroDNI > 99999999){
        alert("El numero de DNI ingresado no es válido");
    }else{
        var posicionLetra = numeroDNI % 23;        
        for (var i = 0; i < letras.length; i++) {
            if(posicionLetra === i){
                var letraDNICalculada = letras[i];
            }
        }       
        if(letraDNI === letraDNICalculada){
            alert("El número y letra de DNI son correctos");
        }else{
            alert("La letra de DNI ingresada no es correcta");
        }
    }
}

//Ejercicio 5
function ejercicio5(numero){
    var numeroEntero = parseInt(numero);
    if(numeroEntero % 2 === 0){
        return "El numero es par";
    }else{
        return "El numero es impar";
    }    
}

//Ejercicio 6
function ejercicio6(cadena){    
    var cadenaSinEspacios = cadena.replace(/\s+/g, '').toLowerCase();    
    if(cadenaSinEspacios.length % 2 === 0){
        var mitadCadena = cadenaSinEspacios.length / 2;
        var primerMitad = cadenaSinEspacios.substring(0, mitadCadena);
        var segundaMitad = cadenaSinEspacios.substring(mitadCadena);
        segundaMitad = segundaMitad.split('').reverse().join('');
    }else{
        var mitadCadena = parseInt(cadenaSinEspacios.length / 2 + 1);
        var primerMitad = cadenaSinEspacios.substring(0, mitadCadena);
        var segundaMitad = cadenaSinEspacios.substring(mitadCadena - 1);
        segundaMitad = segundaMitad.split('').reverse().join('');
    }   
    
    if(primerMitad === segundaMitad){
        alert("La cadena ingresada es un palíndromo");
    }else{
        alert("La cadena ingresada no es un palíndromo");
    }
}

//Ejercicio 7
function ejercicio7(){
    var sueldo = prompt("Ingrese el sueldo:");
    var aniosAntiguedad = prompt("Ingrese los años de antiguedad:");
    
    if(sueldo < 500 && aniosAntiguedad >= 10){
        sueldo = sueldo * 1.20;
        alert("Se le otorgo un aumento del 20%, su nuevo sueldo es de $" + sueldo);
    }else if(sueldo < 500 && aniosAntiguedad < 10){
        sueldo = sueldo * 1.05;
        alert("Se le otorgo un aumento del 5%, su nuevo sueldo es de $" + sueldo);
    }else if(sueldo >= 500){
        alert("No se le otorgo ningun aumento, su sueldo sigue siendo de $" + sueldo);
    }    
}

//Ejercicio 8
function ejercicio8(){
    var turnoManiana = new Array(5);
    var turnoTarde = new Array(6);
    var turnoNoche = new Array(11);  
    var promedioTurnoManiana = 0;
    var promedioTurnoTarde = 0;
    var promedioTurnoNoche = 0;
    
    for (var i = 0; i < turnoManiana.length; i++) {
        turnoManiana[i] = parseInt(prompt("Ingrese la " + (i+1) + "º edad del turno mañana:"));
        promedioTurnoManiana += turnoManiana[i];
    }   
    for (var i = 0; i < turnoTarde.length; i++) {
        turnoTarde[i] = parseInt(prompt("Ingrese la " + (i+1) + "º edad del turno tarde:"));
        promedioTurnoTarde += turnoTarde[i]; 
    }    
    for (var i = 0; i < turnoNoche.length; i++) {
        turnoNoche[i] = parseInt(prompt("Ingrese la " + (i+1) + "º edad del turno noche:"));
        promedioTurnoNoche += turnoNoche[i]; 
    }
   
    promedioTurnoManiana = promedioTurnoManiana / turnoManiana.length; 
    promedioTurnoTarde = promedioTurnoTarde / turnoTarde.length;
    promedioTurnoNoche = promedioTurnoNoche / turnoNoche.length;
    
    alert("El promedio del turno mañana es: " + promedioTurnoManiana);
    alert("El promedio del turno tarde es: " + promedioTurnoTarde);
    alert("El promedio del turno noche es: " + promedioTurnoNoche);       
    
    var mayorPromedio = Math.max(promedioTurnoManiana, promedioTurnoTarde, promedioTurnoNoche);
    if(mayorPromedio === promedioTurnoManiana){
        alert("El turno con el mayor promedio de edades es el turno mañana");
    } else if(mayorPromedio === promedioTurnoTarde){
        alert("El turno con el mayor promedio de edades es el turno tarde");
    } else if(mayorPromedio === promedioTurnoNoche){
        alert("El turno con el mayor promedio de edades es el turno noche");
    } 
}

//Ejercicio 9
function ejercicio9(){    
    var select = document.getElementById("tipos");    
    var opcionElegida = select.options[select.selectedIndex].value;
    
    var p = document.getElementById("precio");
    if (opcionElegida === "1") {
        p.childNodes[0].nodeValue = 'Precio: $140';
    } else if (opcionElegida === "2"){
        p.childNodes[0].nodeValue = 'Precio: $110';
    } else {
        p.childNodes[0].nodeValue = 'Precio: $150';
    }
}

//Ejercicio 10
function ejercicio10(){
    var radio = document.getElementsByName("edad");
    if (radio[0].checked) {
        alert("Puede ingresar al sitio");
    } else if (radio[1].checked) {
        alert("No puede ingresar al sitio");
    }
}

//Ejercicio 11
function ejercicio11(){
    var abrir = open("","","width=600,height=300");
}

//Ejercicio 12
function suma(valor1, valor2){
    this.valor1 = valor1;
    this.valor2 = valor2;
    this.primervalor = function(valor){
        this.valor1 = valor;
    };
    this.segundovalor = function(valor){
        this.valor2 = valor;
    };
    this.retornarresultado = function(){
        return this.valor1 + this.valor2;
    };
}

function ejercicio12(){
    var s = new suma();
    s.primervalor(10);
    s.segundovalor(20);
    document.write('La suma de los dos valores es ' + s.retornarresultado());  
}

//Ejercicio 13
function ejercicio13(){
    var primerVector = new Array(10);        
    for (var i = 0; i < primerVector.length; i++) {
        primerVector[i] = Math.floor((Math.random() * 500) + 1);        
    }
        
    var segundoVector = new Array();
    var tercerVector = new Array();        
    for (var i = 0; i < primerVector.length; i++) {
        if (primerVector[i] < 250) {
            segundoVector.push(primerVector[i]);
        } else {
            tercerVector.push(primerVector[i]);
        }
    }
    
    alert("El segundo vector tiene " + segundoVector.length + " elementos.");
    alert("El tercer vector tiene " + tercerVector.length + " elementos.");
    
    for (var i = 0; i < primerVector.length; i++) {
        alert((i+1) + "º numero del primer vector: " + primerVector[i]);
    }
    
    for (var i = 0; i < segundoVector.length; i++) {
        alert((i+1) + "º numero del segundo vector: " + segundoVector[i]);
    }
    
    for (var i = 0; i < tercerVector.length; i++) {
        alert((i+1) + "º numero del tercer vector: " + tercerVector[i]);
    }
}

//Ejercicio 14
function ejercicio14(){
    var div = document.getElementById("numero");
    div.childNodes[0].nodeValue = div.childNodes[0].nodeValue * 2;  
}

//Ejercicio 15
function ejercicio15(){
    var nombre = document.getElementsByName("nombre")[0].value;
    var primerApellido = document.getElementsByName("primerApellido")[0].value;
    var segundoApellido = document.getElementsByName("segundoApellido")[0].value;
    var telefonoContacto = document.getElementsByName("telefonoContacto")[0].value;
    var email = document.getElementsByName("email")[0].value;
    var tipoTarjeta = document.getElementsByName("tipoTarjeta")[0].value;
    var numeroTarjeta = document.getElementsByName("numeroTarjeta")[0].value;
    var nombreUsuario = document.getElementsByName("nombreUsuario")[0].value;
    var contrasenia = document.getElementsByName("contrasenia")[0].value;
    var verificarContrasenia = document.getElementsByName("verificarContrasenia")[0].value;
    var hayError = false;
    
    if(telefonoContacto !== ""){
        if(!(/^\d+$/.test(telefonoContacto))){
            alert("ERROR: El telefono del contacto solo recibe valores numericos");
            hayError = true;
        }
    }
    
    if(email !== ""){
        if (!(/@[a-zA-Z]+.com/.test(email))) {
            alert("ERROR: El e-mail debe contener un simbolo @ y terminar en .com");
            hayError = true;
        }
    }
    
    if(contrasenia !== verificarContrasenia){
        alert("ERROR: Las contraseñas no son las mismas");
        hayError = true;
    }
        
    if(!hayError){
        alert("Nombre: " + nombre + 
              "\nPrimer Apellido: " + primerApellido + 
              "\nSegundo Apellido: " + segundoApellido +
              "\nTeléfono del Contacto: " + telefonoContacto + 
              "\nE-mail: " + email + 
              "\nTipo de Tarjeta: " + tipoTarjeta + 
              "\nNumero de Tarjeta: " + numeroTarjeta + 
              "\nNombre de Usuario: " + nombreUsuario +
              "\nContraseña: " + contrasenia);
    }
}