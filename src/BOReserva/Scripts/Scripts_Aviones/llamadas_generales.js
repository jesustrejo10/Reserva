
    //EVENTO PARA AGREGAR UN AVION
    $("#aceptarAvion").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formGuardarAvion");
        $.ajax({
            url: "gestion_aviones/guardarAvion",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Se guardo");
                $('#formGuardarAvion')[0].reset();
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    });

    $("#modificarAvion").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formGuardarAvion");
        $.ajax({
            url: "gestion_aviones/modificarAvion",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Avión modificado");

                url = '/gestion_aviones/M02_VisualizarAviones';
                method = 'GET';
                data = '';

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

    $("#cancelarModificacion").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_VisualizarAviones';
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


