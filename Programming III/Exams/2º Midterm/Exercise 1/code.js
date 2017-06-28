function validarMostrarDatos(){    
    var hayErrores = false;
    if($('#deporte').val() !== ''){
        var deporte = $('#deporte').val();
    }else{
        alert('No se ingreso el nombre del deporte');
        hayErrores = true;
    }
    
    if($('#clasificacion').val() !== ''){
        var clasificacion = $('#clasificacion').val();
    }else{
        alert('No se especifico una clasificacion');
        hayErrores = true;
    }
    
    if($('input[name=tipo]:checked').val() !== undefined){
        var tipo = $('input[name=tipo]:checked').val();
    }else{
        alert('No se especifico el tipo');
        hayErrores = true;
    }

    if($('#cantJugadores').val() !== ''){
        var cantJugadores = parseInt($('#cantJugadores').val());    
    }else{
        alert('No se ingreso la cantidad de jugadores');
        hayErrores = true;
    }
    
    if($('#categoriaInfatil').prop('checked') || $('#categoriaJuvenil').prop('checked') || $('#categoriaMayores').prop('checked')){
        var categoria = '';
        if($('#categoriaInfatil').prop('checked')){
            categoria = $('#categoriaInfatil').val();
        }
        if($('#categoriaJuvenil').prop('checked')){
            if(categoria !== ''){
                categoria += ', ' + $('#categoriaJuvenil').val();
            }else{
                categoria = $('#categoriaJuvenil').val();
            }            
        }
        if($('#categoriaMayores').prop('checked')){
            if(categoria !== ''){
                categoria += ', ' + $('#categoriaMayores').val();
            }else{
                categoria = $('#categoriaMayores').val();
            }           
        }                
    }else{
        alert('No se especifico una categoria');
        hayErrores = true;
    }    
    
    if($('#descripcion').val() !== ''){
        var descripcion = $('#descripcion').val();
    }else{
        alert('No se ingreso una descripcion');
        hayErrores = true;
    }   
    
    if(tipo === 'Individual'){
        if(cantJugadores !== 1){
            alert('Si el tipo de deporte es Individual, la cantidad de jugadores debe ser igual a 1');
            hayErrores = true;
        }
    }else if(tipo === 'Colectivo'){
        if(cantJugadores <= 1 || cantJugadores >= 50){
            alert('Si el tipo de deporte es Colectivo, la cantida de jugadores debe ser mayor a 1 y menor a 50');
            hayErrores = true;
        }
    } 
    
    if(!hayErrores){             
        alert('Deporte: ' + deporte + '\n' + 
              'Clasificacion: ' + clasificacion + '\n' + 
              'Tipo: ' + tipo + '\n' + 
              'Cantidad de Jugadores: ' + cantJugadores + '\n' + 
              'Categorias: ' + categoria + '\n' +  
              'Descripcion: ' + descripcion);
    } 
}