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
            $('#formModificarRestaurante')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});