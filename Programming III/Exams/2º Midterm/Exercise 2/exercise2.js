function precioVentaFinal(pPrecioCompra, pMargenGanancia, pIva){
    var precioCompra = parseFloat(pPrecioCompra);
    var margenGanancia = parseFloat(pMargenGanancia);
    var iva = parseFloat(pIva);
    
    var precioFinal = precioCompra + margenGanancia + iva;
    alert(precioFinal);
}


