$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
    $.getJSON("gestion_ruta_comercial/cargarDestinos", { ciudadO: cID },
           function (data) {
               var select = $("#ciudadD");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione una ciudad destino"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});

$("#enviar").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarRuta");
    var origen = $('#rutaOrigen').find(":selected").text();
    var destino = $('#rutaDestino').find(":selected").text();
    $.ajax({
        url: "gestion_ruta_comercial/guardarRuta",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Ruta guardada exitosamente");
            $('#formGuardarRuta')[0].reset();
        }, error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }

    });
});


$('#distanciaRuta').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

$('#distanciaRuta').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});