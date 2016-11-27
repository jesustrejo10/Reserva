jQuery(document).ready(function () {

    $("#gestionAviones").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_GestionAviones';
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

    $("#m08AgregarAutomovil").click(function (e) {
        alert("hola jeffrey");
        
        e.preventDefault();
        var url = '/gestion_automoviles/M08_AgregarAutomovil';
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

    $("#gestionUsuarios").click(function (e) {
        e.preventDefault();
        var url = '/gestion_usuarios/M12_Index';
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

});
