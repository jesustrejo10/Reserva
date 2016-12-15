$("#aceptarPlato").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formGuardarPlato");
    $.ajax({
        url: "gestion_comida_vuelo/guardarPlato",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se guardo");
            $('#formGuardarPlato')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

$("#modificarPlato").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formGuardarPlato");
    $.ajax({
        url: "gestion_comida_vuelo/modificarPlato",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Avión modificado");

            url = '/gestion_comida_vuelo/M06_VisualizarComidas';
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

$("#guardarPlatoVuelo").click(function (e) {
    e.preventDefault();
    var url = '/gestion_comida_vuelo/M06_VisualizarComidas';
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