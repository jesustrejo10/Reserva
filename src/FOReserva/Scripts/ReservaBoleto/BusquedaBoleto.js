$("#buscarVuelos").click(function (e) {
    e.preventDefault();
    var form = $("#formBuscarVuelo");
    $.ajax({
        url: "gestion_reserva_boleto/buscar_vuelos",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se están buscando los vuelos");
            console.log("data", data);
            var url = '/gestion_reserva_boleto/busqueda_parametros';
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

            var url = '/gestion_reserva_boleto/busqueda_resultados';
            var method = 'GET';
            var data = data;

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
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});