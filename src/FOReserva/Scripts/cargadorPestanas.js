jQuery(document).ready(function () {

    /* NO QUITAR ESTA CARGA INICIAL QUE ES LA QUE HARÁ QUE POR DEFAULT SALGA VENTA DE VUELOS AL INICIAR LA PAGINA*/
    $("#contenedor").empty();
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
    });



    /* CARGADOR DE LA PESTAÑA HOTELES*/
    $("#LiHoteles").click(function (e) {
        e.preventDefault();

        $("#LiHoteles").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiRestaurantes").removeClass("active");
        $("#LiCruceros").removeClass("active");
    });



    /* CARGADOR DE LA PESTAÑA RESTAURANTES*/
    $("#LiRestaurantes").click(function (e) {
        e.preventDefault();

        $("#LiRestaurantes").addClass("active");

        $("#LiVuelos").removeClass("active");
        $("#LiHoteles").removeClass("active");
        $("#LiAutos").removeClass("active");
        $("#LiCruceros").removeClass("active");
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
    });
});
