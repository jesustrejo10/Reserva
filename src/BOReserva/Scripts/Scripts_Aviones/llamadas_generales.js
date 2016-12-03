
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

