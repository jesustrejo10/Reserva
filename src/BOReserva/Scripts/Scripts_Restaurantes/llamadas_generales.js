

//EVENTO PARA AGREGAR UN RESTAURANTE
$("#aceptarRestaurante").click(function (e) {
    console.log("Enviando...");
    e.preventDefault();
    e.stopImmediatePropagation();

    var nombre = $("#Nombre").val();
    var descripcion = $("#Descripcion").val();
    var direccion = $("#Direccion").val();
    var telefono = $("#Telefono").val();
    var idlugar = $('#ComboLugar :selected').val();
    var horaini = $('#ComboHoraIni :selected').text();
    var horafin = $('#ComboHoraFin :selected').text();

    $.ajax({
        url: "gestion_restaurantes/guardarRestaurante",
        data: { Nombre: nombre, Descripcion: descripcion, Direccion: direccion, Telefono: telefono, idLugar: idlugar, HoraIni: horaini, HoraFin: horafin },
        dataType: "json",
        type: 'POST',
        success: function (data) {
            alert("El restaurante se agrego con exito.");
            $('#formGuardarRestaurante')[0].reset();

            var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
            var method = 'GET';
            var data = '';

            $.ajax(
                {
                    url: url,
                    type: method,
                    data: data,
                    success: function (data, textStatus, jqXHR) {

                        $("#contenido").empty();
                        $("#contenido").append(data);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//EVENTO PARA LA MODIFICACIÓN DE RESTAURANTES

$(".modificar").click(function () {
  
    var identificador = $(this).parent().parent().parent().attr("id");
    
    jQuery.ajax({
        type: "GET",
        url: "/gestion_restaurantes/M10_GestionRestaurantes_Modificar",
        data: { id: identificador }
    }).done(function (data) {
        $("#contenido").empty();
        $("#contenido").append(data);
    }).fail(function () {

    });


});

//EVENTO PARA LA ELIMINACIÓN DE RESTAURANTES

$(".eliminar").click(function () {
    var identificador = $(this).parent().parent().parent().attr("id");
    jQuery.ajax({
        type: "GET",
        url: "gestion_restaurantes/eliminarRestaurante",
        data: { id: identificador },
        success: function (data) {
            alert("El restaurante se elimino con exito.");

            var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
            var method = 'GET';
            var data = '';

            $.ajax(
                {
                    url: url,
                    type: method,
                    data: data,
                    success: function (data, textStatus, jqXHR) {

                        $("#contenido").empty();
                        $("#contenido").append(data);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });

        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });


});

//EVENTO PARA GUARDAR LA MODIFICACIÓN DE UN RESTAURANTE

$("#aceptarRestauranteModificacion").click(function (e) {
    console.log("Enviando...");
    e.preventDefault();
    e.stopImmediatePropagation();

    var id = $("#Id").val();
    var nombre = $("#Nombre").val();
    var descripcion = $("#Descripcion").val();
    var direccion = $("#Direccion").val();
    var telefono = $("#Telefono").val();
    var idlugar = $('#ComboLugar :selected').val();
    var horaini = $('#ComboHoraIni :selected').text();
    var horafin = $('#ComboHoraFin :selected').text();
  
    $.ajax({
        url: "gestion_restaurantes/modificarRestaurante",
        data: {Id:id, Nombre: nombre, Descripcion: descripcion, Direccion: direccion, Telefono: telefono, idLugar: idlugar, HoraIni: horaini, HoraFin: horafin },
        dataType: "json",
        type: 'POST',
        success: function (data) {
            alert("El restaurante se modifico con exito.");

            var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
            var method = 'GET';
            var data = '';

            $.ajax(
                {
                    url: url,
                    type: method,
                    data: data,
                    success: function (data, textStatus, jqXHR) {

                        $("#contenido").empty();
                        $("#contenido").append(data);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });

        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//EVENTO PARA CANCELAR LA MODIFICACIÓN DE UN RESTAURANTE

$("#cancelarRestauranteModificacion").click(function (e) {
    var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});