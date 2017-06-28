var x;
x = $(document);
x.ready(inicializarEventos);

function inicializarEventos(){
    var x;
    x = $("#boton1");
    x.click(modificarPrimerTabla);
}

function modificarPrimerTabla(){
    var tabla = $("#tabla1");    
    tabla.find("td").text('-');   
}
