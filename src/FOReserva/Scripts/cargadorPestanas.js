jQuery(document).ready(function () {

    /* NO QUITAR ESTA CARGA INICIAL QUE ES LA QUE HARÁ QUE POR DEFAULT SALGA VENTA DE VUELOS AL INICIAR LA PAGINA*/
    $("#contenedor").empty();
    var url = '/gestion_reserva_habitaciones/mis_reservas';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenedor").empty();
                $("#contenedor").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });

    $("#contenedorImagenes").empty();
    var url = '/gestion_vuelos/gestion_vuelosImagenes';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenedorImagenes").empty();
                $("#contenedorImagenes").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

/* Cargador Generico */
function cargarContenido(seccion, tipo, url, data) {

    // 1T : 1 columna, Todo el ancho de la pagina
    // 2D : 2 columnas, contenido derecha
    // 2I : 2 columnas, contenido izquierda
    $.ajax(
        {
            url: url,
            type: tipo,
            data: data,
            success: function (data, textStatus, jqXHR) {
                if (seccion == '#2D' || seccion == '#2I') {
                    $("#1T").hide();
                    $("#2C").show();
                } else {
                    $("#1T").show();
                    $("#2C").hide();
                }

                $(seccion).empty();
                $(seccion).append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
};
console.log("Listo");