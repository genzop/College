var x;
x = $(document);
x.ready(inicializarEventos);

function inicializarEventos(){
    var x;
    x = $("#boton1");
    x.click(vinculoGoogle);
    x = $("#boton2");
    x.click(vinculoYahoo);
    x = $("#boton3");
    x.click(vinculoMicrosoft);
}

function vinculoGoogle(){    
    $("#vinculoweb").attr("href", "https://www.google.com.ar"); 
    $("#vinculoweb").text($("#vinculoweb").attr("href"));
}

function vinculoYahoo(){
    $("#vinculoweb").attr("href", "https://espanol.yahoo.com/"); 
    $("#vinculoweb").text($("#vinculoweb").attr("href"));
}

function vinculoMicrosoft(){
    $("#vinculoweb").attr("href", "https://www.microsoft.com/es-ar/"); 
    $("#vinculoweb").text($("#vinculoweb").attr("href"));
}

