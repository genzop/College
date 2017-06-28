var x;
x = $(document);
x.ready(inicializarEventos);

function inicializarEventos(){
    var x;
    x = $("li");
    x.click(ocultar);
}

function ocultar(){
    $(this).hide("slow");
}