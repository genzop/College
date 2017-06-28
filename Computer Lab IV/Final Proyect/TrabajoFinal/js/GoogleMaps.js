var map;

function initMap() {

    //Se cargan las coordenadas
    var latitud = document.getElementById('cphContenido_txtLatitud').value;
    var longitud = document.getElementById('cphContenido_txtLongitud').value;

    //Si no estan vacias las coordenadas
    if (latitud != "" && longitud != "") {
        
        //El mapa se centra en ese lugar
        latitud = convertirCoordenada(latitud);
        longitud = convertirCoordenada(longitud);
        var myLatlng = new google.maps.LatLng(latitud, longitud);

    } else {
        //El mapa se centra en el centro de Mendoza
        var myLatlng = new google.maps.LatLng(-32.8897629, -68.8314742);
    }
    
    //Configuraciones del mapa
    var mapOptions = {
        zoom: 16,
        center: myLatlng
    };

    //Se crea el mapa
    map = new google.maps.Map(document.getElementById('mapa'), mapOptions);

    //Si no estan vacias las coordenadas
    if (latitud != "" && longitud != "") {

        //Se crea un marcador con la ubicacion 
        var marker = new google.maps.Marker({
            position: { lat: latitud, lng: longitud },
        });

        marker.setMap(map);
    }
}

//Se convierten las coordenadas de texto a numero
function convertirCoordenada(coordenada) {
    coordenada = coordenada.replace(",", ".");
    coordenada = parseFloat(coordenada);

    return coordenada;
}