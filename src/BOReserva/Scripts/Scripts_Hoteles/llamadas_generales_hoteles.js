
    //EVENTO PARA AGREGAR UN HOTEL
    $("#aceptarhotel").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formCrearHotel");
        $.ajax({
            url: "gestion_aviones/crearhotel",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Se guardo");
                $('#formCrearHotel')[0].reset();
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    });

