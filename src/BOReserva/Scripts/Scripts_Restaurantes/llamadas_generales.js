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
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});