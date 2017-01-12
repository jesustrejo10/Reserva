$('.combo').change(function () {
    var idCiudad = $('#combo :selected').val();
    var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
    var method = 'GET';
    alert(idCiudad);
    $.ajax
          ({
              url: url,
              type: method,
              
              data: { id: idCiudad },
              success: function (data, textStatus, jqXHR) {

                  //  $("#contenido").html(data);
                  $("#contenido").empty();
                  $("#contenido").append(data);
              },
              error: function (jqXHR, textStatus, errorThrown) {
                  alert(errorThrown);
              }
          });

});








//EVENTO PARA AGREGAR UN RESTAURANTE
$("#aceptarRestaurante").click(function (e) {
    console.log("Enviando...");
    e.preventDefault();
    e.stopImmediatePropagation();
    var form = $("#formGuardarRestaurante");
    $.ajax({
        url: "gestion_restaurantes/guardarRestaurante",
        data: form.serialize(),
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
    var form = $("#formModificarRestaurante");
    $.ajax({
        url: "gestion_restaurantes/modificarRestaurante",
        data: form.serialize(),
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