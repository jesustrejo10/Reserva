
//EVENTO PARA AGREGAR UNA OFERTA
$("#btnGuardarOferta").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarOferta");
    $.ajax({
        url: "gestion_ofertas/guardarOferta",
        data: form.serialize(),
        //data: { 'nombreOferta': $("#nombreOferta").val(), 'fInicio': $("#fInicio").val(), 'fFin': $("#fFin").val(), 'porcentajeOferta': $("#porcentajeOferta").val() },
        type: 'POST',
        success: function (data) {
            alert("La oferta ha sido creada");
            $('#formGuardarOferta')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});