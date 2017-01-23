    //EVENTO PARA BUSCAR LOS VUELOS
   /* $("#buscarVuelos").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formBuscarVuelo");
        $.ajax({
            url: "gestion_boletos/buscarVuelos",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Se están buscando los vuelos");
                console.log("data", data);
                var url = '/gestion_boletos/M05_VerVuelos';
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
    });*/
