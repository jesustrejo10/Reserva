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
    //INICIO M06_Gestion_Comida
    $("#gestionComida").click(function (e) {
        //M06_AgregarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarComida';
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
    $("#editarComida").click(function (e) {
        //M06_EditarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_EditarComida';
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
    $("#gestionComidaVuelo").click(function (e) {
        //M06_AgregarPorVuelo
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarPorVuelo';
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
    //FIN M06_Gestion_Comida
});
