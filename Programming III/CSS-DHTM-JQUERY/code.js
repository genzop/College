//Ejercicio 2
function fuentePequenia(){
    var parrafo = document.getElementById("miparrafo");
    parrafo.style.fontSize="10px";
}

function fuenteMediana(){
    var parrafo = document.getElementById("miparrafo");
    parrafo.style.fontSize="13px";
}

function fuenteGrande(){
    var parrafo = document.getElementById("miparrafo");
    parrafo.style.fontSize="20px";
}

//Ejercicio 3
function contador(){
    var titulo = document.getElementById("titulo");
    var numero = parseInt(titulo.childNodes[0].nodeValue) + 1;
    titulo.childNodes[0].nodeValue = numero;
}

//Ejercicio 4
function cambiarTamFuente(){
    var cuerpo = document.getElementById("parrafo1").parentNode;
    cuerpo.style.fontSize="40px";
}

//Ejercicio 5
function cambiarColor(){
    var parrafos = document.getElementsByTagName("p");    
    for (var i = 0; i < parrafos.length; i++) {
        parrafos[i].style.color="blue";
    }
}

//Ejercicio 6
function mostrarSoluciones(){
    var lista = document.getElementById("lista");
    var item1 = document.createElement("li");
    var texto1 = document.createTextNode("Primer item");
    item1.appendChild(texto1);
    lista.appendChild(item1);
    var item2 = document.createElement("li");
    var texto2 = document.createTextNode("Segundo item");
    item2.appendChild(texto2);
    lista.appendChild(item2);
}

//Ejercicio 7
function definirAtributo(){
    var tabla = document.getElementById('tabla1');
    tabla.setAttribute('style', 'border: 5px black solid');
}

//Ejercicio 8
function verificarLogin(){
    var usuario = document.getElementById('usuario');
    var contrasenia = document.getElementById('contrasenia');
    var verificarContrasenia = document.getElementById('verificarContrasenia');
    var divError = document.getElementById("error");
    var error = '';
    
    if(usuario.value === ''){
        error = 'ERROR: Es necesario ingresar un nombre de usuario<br>';
    }
    if(contrasenia.value === ''){
        error = error + 'ERROR: Es necesario ingresar una contraseña<br>';
    }
    if(contrasenia.value !== verificarContrasenia.value){
        error = error + 'ERROR: Las contraseñas no coinciden';
    }
    
    if(error !== ''){        
        divError.innerHTML=error;
    }else{
        for (var i = 0; i < divError.childNodes.length; i++) {
            divError.removeChild(divError.childNodes[i]);
        }        
    }   
}


