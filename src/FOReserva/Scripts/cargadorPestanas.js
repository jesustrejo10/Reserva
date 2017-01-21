﻿function mostrarContenedor(posicion) {

    $(".contenedor").hide();
    if (posicion > 0 && posicion <= $(".contenedor").length) {
        $($(".contenedor")[posicion - 1]).show();
    } else {
        $($(".contenedor")[0]).show();
    }
}

/* Cargador Generico */
function cargarContenido(seccion, tipo, url, data, boton) {

    // tipo CP : 1 columna, Todo el ancho de la pagina
    // tipo MD : 2 columnas, contenido derecha
    // tipo MI : 2 columnas, contenido izquierda
    // tipo CL : 2 columnas, contenido izquierda

    if (seccion == '#MD' || seccion == '#MI') {
        mostrarContenedor(1)
    }/* else if (seccion == '#CI') {
        mostrarContenedor(3)
    }*/ else if (seccion == '#CP') {
        mostrarContenedor(2)
    }

    if (seccion == "#MD")
        seccion = "#contenedor"
    else if (seccion == "#MI")
        seccion = "#contenedorImagenes"
    else if (seccion == "#CI")
        seccion = "#contenedorPerfil"

    $(seccion)
        .empty()
        .append($("<div />", { class: "text-center", text: "Cargando..." }));

    $.ajax(
        {
            url: url,
            type: tipo,
            data: data,
            success: function (data, textStatus, jqXHR) {
                $(seccion)
                    .empty()
                    .append(data);

                if (boton != null)
                {
                    $(boton).parent().parent().children().removeClass("active")
                    $(boton).parent().addClass("active")
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
};


jQuery(document).ready(function () {

    mostrarContenedor(1)

    /* NO QUITAR ESTA CARGA INICIAL QUE ES LA QUE HARÁ QUE POR DEFAULT SALGA VENTA DE VUELOS AL INICIAR LA PAGINA*/
    $("#contenedor").html('<div class="text-center">Cargando...</div>');
    var url = '/gestion_vuelos/gestion_vuelos';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {
                console.log('hola carlos')
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
    console.log("test");





    /* CARGADOR DE LA PESTAÑA VUELOS*/
    $("#LiVuelos").click(function (e) {
        e.preventDefault();
        $("#LiVuelos").addClass("active");

        $("#LiAutos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiCruceros").removeClass("active");
        $("#LiDiarios").removeClass("active");

        $("#contenedor").html('<div class="text-center">Cargando...</div>');

        var url = '/gestion_vuelos/gestion_vuelos';
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


    /* CARGADOR DE LA PESTAÑA AUTOS*/
    $("#LiAutos").click(function (e) {
        e.preventDefault();

        $("#LiAutos").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiCruceros").removeClass("active");
        $("#LiDiarios").removeClass("active");

        $("#contenedor").html('<div class="text-center">Cargando...</div>');

        var url = '/gestion_reserva_auto/M19_Reserva_Autos';
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
                    $("#contenedor").html('<div class="text-center">No se pudo cargar la data</div>');
                }
            });

        var url = '/gestion_reserva_auto/M19_Reserva_AutosImagenes';
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



    /* CARGADOR DE LA PESTAÑA HOTELES*/
    $("#LiHoteles").click(function (e) {
        e.preventDefault();

        $("#LiHoteles").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiCruceros").removeClass("active");
        $("#LiDiarios").removeClass("active");
    });



    /* CARGADOR DE LA PESTAÑA RESTAURANTES*/
    $("#LiRestaurantes").click(function (e) {
        e.preventDefault();

        $("#LiRestaurantes").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiCruceros").removeClass("active");
        $("#LiDiarios").removeClass("active");

        $("#contenedor").html('<div class="text-center">Cargando...</div>');

        var url = '/gestion_reserva_restaurante/gestion_reserva_restaurante';
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


   /* CARGADOR DE LA PESTAÑA CRUCEROS*/
    $("#LiCruceros").click(function (e) {
        e.preventDefault();

        $("#LiCruceros").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiDiarios").removeClass("active");

        $("#contenedor").html('<div class="text-center">Cargando...</div>');

        var url = '/gestion_reserva_crucero/gestion_reserva_crucero';
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
                    $("#contenedor").html('<div class="text-center">No se pudo Cargar los datos...</div>');
                }
            });

        var url = '/gestion_reserva_crucero/gestion_reserva_cruceroImagenes';
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


    /* CARGADOR DE LA PESTAÑA DIARIOS DE VIAJE*/
    $("#LiDiarios").click(function (e) {
        e.preventDefault();

        $("#LiDiarios").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiCruceros").removeClass("active");

        $("#contenedor").html('<div class="text-center">Cargando...</div>');

        var url = '/gestion_diarios/gestion_diarios';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                dataType: "html",
                success: function (data, textStatus, jqXHR) {

                    $("#contenedor").empty();
                    $("#contenedor").html(data);


                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

        var url = '/gestion_diarios/gestion_diariosImagenes';
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
});
