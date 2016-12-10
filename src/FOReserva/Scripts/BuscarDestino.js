//EVENTO PARA BUSCAR LOS VUELOS
$("#buscarDestino").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formbuscarDestino");
    $.ajax({
        url: "gestion_planificacion_vacaciones/buscarDestino",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
           alert("Se están buscando los vuelos");
            console.log("data", data);
            var url = '/gestion_planificacion_vacaciones/gestion_itinerario';
            var method = 'GET';
            var data = data;
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
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});