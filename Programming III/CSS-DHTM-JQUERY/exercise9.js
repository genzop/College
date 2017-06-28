var x;
x=$(document);
x.ready(inicializarEventos);

function inicializarEventos(){
    var x;
    x = $("#fila1");
    x.click(cambiarColorFila);
    x = $("#fila2");
    x.click(cambiarColorFila);
}

function cambiarColorFila(){
    var backgroundColor = $(this).css('background-color');    
    if(backgroundColor === 'rgb(255, 215, 0)'){
        $(this).css('background-color', '#ffffff');
    } else {
        $(this).css('background-color', '#ffd700');  
    }        
}
