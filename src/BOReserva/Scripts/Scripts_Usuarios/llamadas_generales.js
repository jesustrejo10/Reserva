$("#cancelarModificacion").click(function (e) {
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


$(".modificarUsuario_form").submit(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $(".modificarUsuario_form");
    $.ajax({
        url: "gestion_usuarios/M12_ModificarUsuario",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            toIndex();
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});

function toIndex() {
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
};

$(".agregarUsuario_form").submit(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $(".agregarUsuario_form");
    $.ajax({
        url: "gestion_usuarios/M12_AgregarUsuario2",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            toIndexA();
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});

function toIndexA() {
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
};
