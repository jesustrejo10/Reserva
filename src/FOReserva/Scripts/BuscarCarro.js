$("#BuscarCarro").click(function (e) {
    console.log("hola");
    e.preventDefault();
    var form = $("#formBuscarCarro");
    
    $.ajax(
        {
            url: "gestion_reserva_auto/Cvista_ReservaAutos",
            type: 'POST',
            data: form.serialize,
            success: function (data) {
                alert("Se estan buscando los carros");
                var url = "gestion_reserva_auto/M19_Reserva_Autos";
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



                
            },
            error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
            }
        });

});
