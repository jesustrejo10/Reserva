//Reclamos
$("#aceptarReclamo").click(function (e) {
    console.log("entro aqui karli");
    e.preventDefault();
    $.ajax({
        url: '/gestion_reclamos/M16_VisualizarReclamo',
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            //alert("Se agregó el Itinerario");
            //  $('#formbuscarDestino')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});