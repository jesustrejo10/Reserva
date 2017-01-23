$("#cancelarModificacion").click(function (e) {
    e.preventDefault();
    var url = '/gestion_usuarios/M12_VisualizarUsuarios';
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

function toIndex() {
    var url = '/gestion_usuarios/M12_VisualizarUsuarios';
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

$("#aceptarUsuario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
   // $("#contenido").html('<div class="text-center">Cargando...</div>');
    var form = $(".agregarUsuario_form");
    $.ajax({
        url: "gestion_usuarios/guardarUsuario",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se registro el Usuario exitosamente");
            $("#contenido").html('<div class="text-center">Cargando...</div>');
            toIndexA();
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});

$("#aceptarUsuario").click(function (e) {
    e.preventDefault();
    var form = $("#agregarUsuario_form");
    var correo = $('#correoUsuario').val();
    var nombre = $('#nombreUsuario').val();
    var apellido = $('#apellidoUsuario').val();
    var contrasena = $('#contrasena').val();
    var confContrasena = $('#confContraseña').val();
    var rol = $('#rolUsuario').val();
    var activo = $('#activoUsuario').val();

    console.log(correo);
    console.log(nombre);
    console.log(apellido);
    console.log(contrasena);
    console.log(confContrasena);
    console.log(rol);
    console.log(activo);
}); 

function toIndexA() {
    var url = '/gestion_usuarios/M12_AgregarUsuario2';
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
