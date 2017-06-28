var x;
x = $(document);
x.ready(inicializarEventos);

function inicializarEventos(){
    var x;
    x = $("#boton1");
    x.click(mostrarHead);
    x = $("#boton2");
    x.click(mostrarBody);
}

function mostrarHead(){
    var x;
    x = $("head");
    alert(x.html());
}

function mostrarBody(){
    var x;
    x = $("body");
    alert(x.html());
}