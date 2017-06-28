function agregarValor(){   
    var valor = document.getElementById('txtValor').value;    
    var combo = document.getElementById('combo');    
    combo.innerHTML += "<option value='" + valor + "'>" + valor + "</option>";    
}


